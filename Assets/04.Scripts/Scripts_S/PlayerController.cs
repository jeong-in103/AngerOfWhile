using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Componet
    public Movement movement; //Player Move Script
    public Material skin;
    private Animator animator;

    // Variable
    public float moveSpeed; //Player Move Speed

    private float startPosY;
    private float startPosZ;

    private int hp = 3; //Player HP
    private int stemina; // Item Aid-Kit Addtional Hp
    private int helmat; // Item Helmat Defense Count

    private bool attack;

    [Range(0f,1f)]
    public float time;   
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        startPosY = transform.position.y;
        startPosZ = transform.position.z;
    }
    private void Update()
    {
        //이동
        Move(); //Mobile Player Move
        PCMove(); //PC Player Move
        LimitMove(); //Limit Player Move

        //공격
        Attack();
        PCAttack();

        // 
        TimeDelay();
    }
 
    #region Player Move
    //Player 이동 
    private void Move()
    {
        if (movement.DirectPos != Vector3.zero)
        {
            Vector3 move = new Vector3(movement.DirectPos.x, startPosY, startPosZ);
            transform.position = Vector3.Slerp(transform.position, move, Time.smoothDeltaTime * moveSpeed);
        }
    }
    //개발 PC용 움직임
    private void PCMove()
    {
        float x = Input.GetAxis("Horizontal");

        if (x > 0f)
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
        else if (x < 0f)
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
    }
    //Player가 카메라 화면밖으로 나가지 않도록
    private void LimitMove()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.1f) pos.x = 0.1f;
        if (pos.x > 0.9f) pos.x = 0.9f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    #endregion

    #region Attack

    private void Attack()
    {
        if (movement.Attack)
        {
            animator.SetTrigger("Attack");
            movement.Attack = false;
        }
    }

    private void PCAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
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
    void OnDamage()
    {
        if (helmat != 0)
        {
            StartCoroutine(Damage());
        }
        else
        {
            helmat--;
        }
    }

    //피격 받았을 때 고래 색깔 빨간색으로
    IEnumerator Damage()
    {
        skin.color = Color.red;
        hp--;
        yield return new WaitForSeconds(0.1f);
        skin.color = Color.black;
    }
    #endregion

    //모션 딜레이 
    private void TimeDelay()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Dive"))
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = time;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
