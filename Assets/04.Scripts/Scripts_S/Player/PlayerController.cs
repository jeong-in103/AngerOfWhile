using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : WhaleBase
{
    public enum State { IDLE, DIVE, ATTACK, DEAD, DAMAGE };
    public State state;

    // Manager
    SoundManager soundManager;

    [Header("Player Interaction Script")]
    // Componet
    public PlayerInteraction PlayerInteraction;
    public DiveBarControl diveBarControl;
    public HeartControl heartControl;
    public ShildControl shildControl;

    public GameObject endingCanvas;

    [Header("Player Interaction Object")]
    public Material skin; //���� ��Ų
    public ParticleSystem[] effects; 

    [HideInInspector]
    public Animator animator;

    [Header("Player Detail Setting")]
    // Variable
    public float timeSpeed = 29f; // ���� �ð� �ӵ�
    public float blinkSpeed; //�� ��ȭ �ӵ�

    public float InvincibleTime = 1f; // ���� �ð�
    private float blinkTime; //�� ��ȭ �ð�

    private float startPosY; // Player �ʱ� ��ġY
    private float startPosZ; // Player �ʱ� ��ġZ

    private int hp; // ü��
    private int stemina; // ���޻��� �߰� HP
    private int helmat; // ��� ����

    private bool damage; //�ǰ�üũ

    private void Awake()
    {
        animator = GetComponent<Animator>();
        soundManager = SoundManager.Instance;
    }
    private void Start()
    {
        hp = 3;
        stemina = 0;
        helmat = 0;

        moveSpeed = 8f; // �̵� �ӵ�

        startPosY = transform.position.y;
        startPosZ = transform.position.z;

        Init();
    }
    private void Update()
    {
        switch (state)
        {
            case State.IDLE:
                Move(); //�̵�
                LimitMove(); //�̵�����
                Dive(); //��� �ִ�
                break;
            case State.DIVE:
                Move(); //�̵�
                LimitMove(); //�̵�����
                AttackWay(); //���� �ִ�
                soundManager.UnderWaterSound();
                break;
            case State.ATTACK:
                if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
                {
                    StartCoroutine(TimeDelay()); //�ð� ������
                }
                break;
            case State.DEAD:
                endingCanvas.gameObject.SetActive(true);
                break;
            case State.DAMAGE:
                if (damage)
                {
                    DamageBlink();
                }
                Move(); //�̵�
                LimitMove(); //�̵�����               
                break;
        }
    }
    //�ʱ�ȭ
    private void Init()
    {
        PlayerInteraction.Dive = false;
        PlayerInteraction.Attack = false;

        animator.ResetTrigger("Dive");
        animator.ResetTrigger("Attack");

        skin.color = Color.black;

        state = State.IDLE;
    }

    #region ���� �̵�
    //Player �̵� 
    private void Move()
    {
        if (PlayerInteraction.DirectPos != Vector3.zero)
        {
            Vector3 move = new Vector3(PlayerInteraction.DirectPos.x, startPosY, startPosZ);
            transform.position = Vector3.Slerp(transform.position, move, Time.smoothDeltaTime * moveSpeed);
        }
    }

    //Player�� ī�޶� ȭ������� ������ �ʵ���
    private void LimitMove()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.1f)
        {
            pos.x = 0.1f;
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
        if (pos.x > 0.9f)
        {
            pos.x = 0.9f;
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
    #endregion

    #region Animaor Control
    //���
    private void Dive()
    {
        if (PlayerInteraction.Dive)
        {
            animator.SetTrigger("Dive");
            diveBarControl.OnDiveBar(); // ���̺�� UI On
            state = State.DIVE;
        }
    }

    //����
    private void Attack()
    {
        animator.SetTrigger("Attack");
        diveBarControl.OffDiveBar(); // ���̺�� UI Off
        soundManager.AttackSound();
        state = State.ATTACK;
    }
    #endregion

    #region ������ ȿ��

    // HP ȸ��
    void HpRecover()
    {
        hp++;
        hp = Mathf.Clamp(hp, 0, 3);
        hp += stemina;
        heartControl.ChangeHP(hp);
    }
    // ���׹̳� �߰� (��Ʈ �߰�)
    void AddStemina()
    {
        if (stemina != 2)
        {
            stemina++;
            stemina = Mathf.Clamp(stemina, 0, 2);
            heartControl.AddHeart();
        }
    }
    #endregion

    #region �ǰݽ�
    public void OnDamage()
    {
        soundManager.DamageSound();

        if (helmat == 0)
        {
            hp--;
            heartControl.ChangeHP(hp); //UI ��Ʈ ����

            //����
            if (hp <= 0)
            {
                soundManager.OnBGM(2);
                state = State.DEAD;
            }
            else
            {
                damage = true;
                state = State.DAMAGE;
            }
        }
        else
        {
            helmat--; //�� ����
            helmat = Mathf.Clamp(helmat, 0, 2);
            if (helmat == 0)
            {
                shildControl.OnBroken(false); //�� �μ��� + �����
            }
            else
            {
                shildControl.OnBroken(true); //�� �μ��� 
            }
        }
    }
    //�ǰ� �޾��� �� ���� ���� ����������
    private void DamageBlink()
    {
        blinkTime += Time.deltaTime;
        if (blinkTime <= InvincibleTime)
        {
            skin.color = new Color(Mathf.PingPong(Time.time * blinkSpeed, 1f), 0f, 0f);
        }
        else
        {
            blinkTime = 0f;
            damage = false;
            Init(); //�ʱ�ȭ
        }
    }

    #endregion

    #region ���ݽ�
    //���ݹ�� (1. �⺻ Ŭ�� ����, 2. ��������)
    private void AttackWay()
    {
        if (PlayerInteraction.Attack) //Ŭ�� ����
        {
            Attack();
        }
        if (!diveBarControl.Diving) //���� ����
        {
            Attack();
        }
    }
    IEnumerator TimeDelay()
    {
        float slowTime = 0f;
        while (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            slowTime = Mathf.Lerp(slowTime, 1f, Time.deltaTime * timeSpeed);
            Time.timeScale = slowTime;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            yield return null;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Time.timeScale = 1.0f;
        Init();
    }

    #endregion

    #region ����Ʈ
    public void AidKitEffect(int num)
    {
        soundManager.AidKitSound();
        if (num == 1)
        {
            //ü�� ȸ��
            effects[0].gameObject.SetActive(true);
            HpRecover();
        }
        else
        {
            //��Ʈ �߰�
            effects[1].gameObject.SetActive(true);
            AddStemina();
        }
    }
    //��ȣ�� ����Ʈ
    public void HelmatEffect(int count)
    {
        shildControl.gameObject.SetActive(true);
        soundManager.HelmatSound();
        if (helmat == 2)
        {
            return;
        }
        else
        {
            helmat = count;
        }
    }

    //���� ����Ʈ?
    public void ClockEffect()
    {
        effects[3].gameObject.SetActive(true);
    }
    #endregion
}