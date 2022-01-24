using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum State {IDLE, DIVE, ATTACK, DAMAGE};
    public State state;

    // Componet
    public PlayerInteraction PlayerInteraction;
    public DiveBarControl diveBarControl;

    public Material skin;
    
    private Animator animator;

    // Variable
    public float timeSpeed = 29f; // ���� �ð� �ӵ�
    public float moveSpeed = 8f; // �̵� �ӵ�
    public float colorSpeed = 0.01f;
    public float InvincibleTime = 1f; // ���� �ð�


    private float startPosY;
    private float startPosZ;

    private int hp; // ü��
    private int stemina; // ���޻��� �߰� HP
    private int helmat; // ��� ����


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
                    StartCoroutine(Invincibility()); //����
                }
                break;
            case State.DAMAGE:
                //����
                OnDamage(); //�ǰ�ȿ��
                break;
        }
    }

    IEnumerator Invincibility()
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
        //boxCollider.enabled = true;

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
            StartCoroutine(Damage());
        }
        else
        {
            helmat--;
        }
    }

    //�ǰ� �޾��� �� �� ���� ����������
    IEnumerator Damage()
    {
        Color targetColor = Color.red;
        while (true)
        {
            skin.color = new Color(Mathf.PingPong(Time.time * colorSpeed ,1f), 0f, 0f);
            yield return new WaitForSeconds(1f);
            break;
        }
        skin.color = Color.black;
        Init(); //�ʱ�ȭ
    }
    #endregion

}
