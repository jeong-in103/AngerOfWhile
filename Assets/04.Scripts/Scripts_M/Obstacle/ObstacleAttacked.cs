using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleAttacked : ObstacleData
{
    [SerializeField]
    private GamePlayManager gamePlayManager;

    private Animator obstacleAnimator;
    private BoxCollider boxCollider;

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
        obstacleCtrl = GetComponent<ObstacleCtrl>();
        obstacleAnimator = GetComponentInChildren<Animator>();
        humanEffect = GetComponentInChildren<HumanExplosion>();
        oilCtrl = GetComponentInChildren<OilCtrl>();
    }

    public void Attacked(int whale)
    {
        if (obstacleAnimator != null)
        {
            obstacleAnimator.SetBool("Attacked", true);
        }
        else if(type.Type == TypeID.OIL)
        {
            oilCtrl.OilDisappear();
        }

        if (humanEffect == true)
        {
            humanEffect.ExpHuman(humanValue);
        }

        if (humansObj == true)
        {
            humansObj.SetActive(false);
        }

        //���� ���
        GameObject scoreText = ObjectPool.GetObj((int)TypeID.TEXT);
        float ran = Random.Range(-2f, 2f);
        scoreText.transform.position = 
            new Vector3(transform.position.x + ran, transform.position.y, transform.position.z + 5f + ran);
        scoreText.GetComponentInChildren<ScoreText>().PrintScore(type.Score);

        tempMoveSpeed = obstacleCtrl.MoveSpeed;
        obstacleCtrl.MoveSpeed = 0f;
        boxCollider.enabled = false;

        if (whale==1) //1.Player�� �ε����� ��� 2.�ʻ�� ������ �ε����� ���
        {
            ScoreAndGauge();
        }
        else
        {
            GameManager.score += type.Score;
        }

        Invoke("ResettingObstacle", destroyDelay);
    }

    private void ResettingObstacle()
    {
        if(obstacleAnimator == true)
        {
            obstacleAnimator.SetBool("Attacked", false);
        }
        else if(type.Type == TypeID.OIL)
        {
            oilCtrl.OilDisappear();
            oilCtrl.StopOilDisappear();
        }

        if(humansObj == true)
        {
            humansObj.SetActive(true);
        }

        if(humanEffect == true)
        {
            humanEffect.Resetting(humanValue);
        }

        ObjectPool.ReturnObj(this.gameObject, (int)type.Type);

        obstacleCtrl.MoveSpeed = tempMoveSpeed;
        boxCollider.enabled = true;
    }

    private void ScoreAndGauge()
    {
        GameManager.angerValue += type.AngerGauge;
        GameManager.score += type.Score;

        gamePlayManager.ScoreHighlight();
    }
}
