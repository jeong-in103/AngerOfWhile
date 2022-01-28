using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections.LowLevel.Unsafe;

public class ObstacleAttacked : ObstacleData
{
    [SerializeField]
    private GamePlayManager gamePlayManager;

    private Animator obstacleAnimator;
    private BoxCollider boxCollider;

    private InstantiateObstacle instantiateObstacle;
    private ObstacleCtrl obstacleCtrl;
    private HumanExplosion humanEffect;
    private OilCtrl oilCtrl;

    [SerializeField]
    private GameObject humansObj;

    [SerializeField]
    private int humanValue;

    [SerializeField]
    private float destroyDelay;
    private float tempMoveSpeed;

    private void Awake()
    {
        gamePlayManager = GameObject.FindWithTag("GamePlayManager").GetComponent<GamePlayManager>();
        boxCollider = GetComponent<BoxCollider>();
        instantiateObstacle = GetComponent<InstantiateObstacle>();
        obstacleCtrl = GetComponent<ObstacleCtrl>();
        obstacleAnimator = GetComponentInChildren<Animator>();
        humanEffect = GetComponentInChildren<HumanExplosion>();
        oilCtrl = GetComponentInChildren<OilCtrl>();
    }

    public void Attacked(int whale)
    {
        // 애니메이션 및 효과
        if (obstacleAnimator != null)
        {
            obstacleAnimator.SetBool("Attacked", true);
        }
        else if (type.Type == TypeID.OIL)
        {
            oilCtrl.OilDisappear();
        }

        // 사람 폭발 이펙트
        if (humanEffect == true)
        {
            humanEffect.ExpHuman(humanValue);
        }

        // 사람 오브젝트 비활성화
        if (humansObj == true)
        {
            humansObj.SetActive(false);
        }

        //점수 출력
        GameObject scoreText = ObjectPool.GetObj(UnsafeUtility.EnumToInt(TypeID.TEXT));
        float ran = Random.Range(-2f, 2f);
        scoreText.transform.position =
            new Vector3(transform.position.x + ran, transform.position.y, transform.position.z + 5f + ran);
        scoreText.GetComponentInChildren<ScoreText>().PrintScore(type.Score);

        // 속도 멈추기
        tempMoveSpeed = obstacleCtrl.MoveSpeed;
        obstacleCtrl.MoveSpeed = 0f;

        // 콜라이더 비활성화
        boxCollider.enabled = false;

        // 점수 증가
        if (!GameManager.endGame)
        {
            if (whale == 1) //1.Player와 부딪혔을 경우 2.필살기 고래랑 부딪혔을 경우
            {
                ScoreAndGauge();
            }
            else
            {
                GameManager.score += type.Score;

                gamePlayManager.ScoreHighlight();
            }
        }
        
        // 장애물 초기화
        Invoke("ResettingObstacle", destroyDelay);
    }

    private void ResettingObstacle()
    {
        // 오브젝트풀 반환
        ObjectPool.ReturnObj(this.gameObject, UnsafeUtility.EnumToInt(type.Type));

        // 애니메이션 및 효과 초기화
        if (obstacleAnimator == true)
        {
            obstacleAnimator.SetBool("Attacked", false);
            if (instantiateObstacle == true)
            {
                instantiateObstacle.IsAttack = false;
            }
        }
        else if (type.Type == TypeID.OIL)
        {
            oilCtrl.StopOilDisappear();
        }

        if (humansObj == true)
        {
            humansObj.SetActive(true);
        }

        if (humanEffect == true)
        {
            humanEffect.Resetting(humanValue);
        }

        // 속도 복구
        obstacleCtrl.MoveSpeed = tempMoveSpeed;

        // 박스 콜라이더 활성화
        boxCollider.enabled = true;
    }

    private void ScoreAndGauge()
    {
        GameManager.angerValue += type.AngerGauge;
        GameManager.score += type.Score;

        gamePlayManager.ScoreHighlight();
    }
}
