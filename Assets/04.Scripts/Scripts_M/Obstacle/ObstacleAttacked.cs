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
        // �ִϸ��̼� �� ȿ��
        if (obstacleAnimator != null)
        {
            obstacleAnimator.SetBool("Attacked", true);
        }
        else if (type.Type == TypeID.OIL)
        {
            oilCtrl.OilDisappear();
        }

        // ��� ���� ����Ʈ
        if (humanEffect == true)
        {
            humanEffect.ExpHuman(humanValue);
        }

        // ��� ������Ʈ ��Ȱ��ȭ
        if (humansObj == true)
        {
            humansObj.SetActive(false);
        }

        //���� ���
        GameObject scoreText = ObjectPool.GetObj(UnsafeUtility.EnumToInt(TypeID.TEXT));
        float ran = Random.Range(-2f, 2f);
        scoreText.transform.position =
            new Vector3(transform.position.x + ran, transform.position.y, transform.position.z + 5f + ran);
        scoreText.GetComponentInChildren<ScoreText>().PrintScore(type.Score);

        // �ӵ� ���߱�
        tempMoveSpeed = obstacleCtrl.MoveSpeed;
        obstacleCtrl.MoveSpeed = 0f;

        // �ݶ��̴� ��Ȱ��ȭ
        boxCollider.enabled = false;

        // ���� ����
        if (!GameManager.endGame)
        {
            if (whale == 1) //1.Player�� �ε����� ��� 2.�ʻ�� ���� �ε����� ���
            {
                ScoreAndGauge();
            }
            else
            {
                GameManager.score += type.Score;

                gamePlayManager.ScoreHighlight();
            }
        }
        
        // ��ֹ� �ʱ�ȭ
        Invoke("ResettingObstacle", destroyDelay);
    }

    private void ResettingObstacle()
    {
        // ������ƮǮ ��ȯ
        ObjectPool.ReturnObj(this.gameObject, UnsafeUtility.EnumToInt(type.Type));

        // �ִϸ��̼� �� ȿ�� �ʱ�ȭ
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

        // �ӵ� ����
        obstacleCtrl.MoveSpeed = tempMoveSpeed;

        // �ڽ� �ݶ��̴� Ȱ��ȭ
        boxCollider.enabled = true;
    }

    private void ScoreAndGauge()
    {
        GameManager.angerValue += type.AngerGauge;
        GameManager.score += type.Score;

        gamePlayManager.ScoreHighlight();
    }
}
