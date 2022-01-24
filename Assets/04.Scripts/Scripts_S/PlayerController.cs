using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public enum State { IDLE, DIVE, ATTACK, DEAD, DAMAGE };
    public State state;

    // Componet
    public PlayerInteraction PlayerInteraction;
    public DiveBarControl diveBarControl;
    public HeartControl heartControl;

    public Material skin;

    private Animator animator;

    // Variable
    public float timeSpeed = 29f; // ���� �ð� �ӵ�
    public float moveSpeed = 8f; // �̵� �ӵ�
    public float blinkSpeed; //�� ��ȭ �ӵ�

    public float InvincibleTime = 1f; // ���� �ð�

    private float blinkTime; //�� ��ȭ �����ð�
    
    private float startPosY;
    private float startPosZ;

    [SerializeField]
    private int hp; // ü��
    private int stemina; // ���޻��� �߰� HP
    private int helmat; // ��� ����
    [SerializeField]
    private bool damage;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        hp = 3;

        startPosY = transform.position.y;
        startPosZ = transform.position.z;
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
                break;
            case State.ATTACK:
                if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
                {
                    StartCoroutine(TimeDelay()); //�ð� ������
                }
                break;
            case State.DEAD:
                
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
        if (damage)
        {
            DamageBlink();
        }
    }

    #region Player Move
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
    private void Dive()
    {
        if (PlayerInteraction.Dive)
        {
            animator.SetTrigger("Dive");
            diveBarControl.OnDiveBar(); // ���̺�� UI On
            state = State.DIVE;
        }
    }
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
    //����
    private void Attack()
    {
        animator.SetTrigger("Attack");
        diveBarControl.OffDiveBar(); // ���̺�� UI Off
        state = State.ATTACK;
    }
    //�ʱ�ȭ
    private void Init()
    {
        PlayerInteraction.Dive = false;
        PlayerInteraction.Attack = false;

        animator.ResetTrigger("Dive");
        animator.ResetTrigger("Attack");

        state = State.IDLE;
    }
    #endregion

    #region ������ ȿ��
    void OnHelmat(int level)
    {
        helmat = level;
    }

    void OnRecover(int level)
    {
        if (level == 1)
        {
            hp++;
        }
        else
        {
            stemina++;
        }
        stemina = Mathf.Clamp(stemina, 0, 2);
        hp = Mathf.Clamp(hp, 0, hp + stemina);
    }
    #endregion

    #region �ǰݽ�
    public void OnDamage()
    {
        if (helmat == 0)
        {
            hp--;
            heartControl.ChangeHP(hp); //UI ��Ʈ ����
            //����
            if (hp <= 0)
            {
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
                      //�� ���� ȿ��
        }
    }

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
            skin.color = Color.black;
        }
    }
    //�ǰ� �޾��� �� �� ���� ����������

    #endregion

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

}
