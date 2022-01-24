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
    public float timeSpeed = 29f; // 정지 시간 속도
    public float moveSpeed = 8f; // 이동 속도
    public float blinkSpeed; //색 변화 속도

    public float InvincibleTime = 1f; // 무적 시간

    private float blinkTime; //색 변화 지정시간
    
    private float startPosY;
    private float startPosZ;

    [SerializeField]
    private int hp; // 체력
    private int stemina; // 구급상자 추가 HP
    private int helmat; // 헬멧 갯수
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
                Move(); //이동
                LimitMove(); //이동제한
                Dive(); //잠수 애니
                break;
            case State.DIVE:
                Move(); //이동
                LimitMove(); //이동제한
                AttackWay(); //공격 애니
                break;
            case State.ATTACK:
                if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
                {
                    StartCoroutine(TimeDelay()); //시간 딜레이
                }
                break;
            case State.DEAD:
                
                break;
            case State.DAMAGE:
                if (damage)
                {
                    DamageBlink();
                }
                Move(); //이동
                LimitMove(); //이동제한
                break;
        }
        if (damage)
        {
            DamageBlink();
        }
    }

    #region Player Move
    //Player 이동 
    private void Move()
    {
        if (PlayerInteraction.DirectPos != Vector3.zero)
        {
            Vector3 move = new Vector3(PlayerInteraction.DirectPos.x, startPosY, startPosZ);
            transform.position = Vector3.Slerp(transform.position, move, Time.smoothDeltaTime * moveSpeed);
        }
    }

    //Player가 카메라 화면밖으로 나가지 않도록
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
            diveBarControl.OnDiveBar(); // 다이브바 UI On
            state = State.DIVE;
        }
    }
    //공격방법 (1. 기본 클릭 공격, 2. 강제공격)
    private void AttackWay()
    {
        if (PlayerInteraction.Attack) //클릭 공격
        {
            Attack();
        }
        if (!diveBarControl.Diving) //강제 공격
        {
            Attack();
        }
    }
    //공격
    private void Attack()
    {
        animator.SetTrigger("Attack");
        diveBarControl.OffDiveBar(); // 다이브바 UI Off
        state = State.ATTACK;
    }
    //초기화
    private void Init()
    {
        PlayerInteraction.Dive = false;
        PlayerInteraction.Attack = false;

        animator.ResetTrigger("Dive");
        animator.ResetTrigger("Attack");

        state = State.IDLE;
    }
    #endregion

    #region 아이템 효과
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

    #region 피격시
    public void OnDamage()
    {
        if (helmat == 0)
        {
            hp--;
            heartControl.ChangeHP(hp); //UI 하트 변경
            //죽음
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
            helmat--; //방어막 깎임
                      //방어막 깎임 효과
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
            Init(); //초기화
            skin.color = Color.black;
        }
    }
    //피격 받았을 때 고래 색깔 빨간색으로

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
