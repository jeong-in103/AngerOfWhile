using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleAttacked : ObstacleData
{
    private Animator obstacleAnimator;
    private BoxCollider boxCollider;
    [SerializeField]
    private Material oilMaterial;
    [SerializeField]
    private Material oilRemoveMaterial;

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
        boxCollider = GetComponent<BoxCollider>();
        obstacleCtrl = GetComponent<ObstacleCtrl>();
        obstacleAnimator = GetComponentInChildren<Animator>();
        humanEffect = GetComponentInChildren<HumanExplosion>();
        oilCtrl = GetComponentInChildren<OilCtrl>();
    }

    public void Attacked()
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

        //점수 출력
        GameObject scoreText = ObjectPool.GetObj((int)TypeID.TEXT);
        float ran = Random.Range(-2f, 2f);
        scoreText.transform.position = 
            new Vector3(transform.position.x + ran, transform.position.y, transform.position.z + 5f + ran);
        scoreText.GetComponentInChildren<ScoreText>().PrintScore(type.Score);

        tempMoveSpeed = obstacleCtrl.MoveSpeed;
        obstacleCtrl.MoveSpeed = 0f;
        boxCollider.enabled = false;
       
        ScoreAndGauge();

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
    }
}
