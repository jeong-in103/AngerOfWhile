using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleAttacked : ObstacleData
{
    private Animator obstacleAnimator;
    private BoxCollider boxCollider;

    private ObstacleCtrl obstacleCtrl;
    private HumanExplosion humanEffect;

    [SerializeField]
    private GameObject humansObj;

    [SerializeField]
    private int humanValue;

    [SerializeField]
    private float destroyDelay;

    [SerializeField]
    private bool testAttackedSwitch = false;

    private float tempMoveSpeed;

    private void Awake()
    {
        obstacleAnimator = gameObject.GetComponentInChildren<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        obstacleCtrl = GetComponent<ObstacleCtrl>();
        humanEffect = GetComponentInChildren<HumanExplosion>();
    }

    private void Update()
    {
        //test 용 코드
        if (testAttackedSwitch == true)
        {
            testAttackedSwitch = false;

            if (obstacleAnimator != null)
            {
                obstacleAnimator.SetTrigger("Attacked");
            }

            if (humanEffect == true)
            {
                humanEffect.ExpHuman(humanValue);
            }

            if(humansObj == true)
            {
                humansObj.SetActive(false);
            }

            obstacleCtrl.MoveSpeed = 0f;
            boxCollider.enabled = false;
            //점수 증가
           
            //분노 게이지 증가

            Invoke("DestroyObstacle", destroyDelay);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Attacked();
    }
    public void Attacked()
    {
        if (obstacleAnimator != null)
        {
            obstacleAnimator.SetBool("Attacked", true);
        }

        if (humanEffect == true)
        {
            humanEffect.ExpHuman(humanValue);
        }

        if (humansObj == true)
        {
            humansObj.SetActive(false);
        }

        tempMoveSpeed = obstacleCtrl.MoveSpeed;
        obstacleCtrl.MoveSpeed = 0f;
        boxCollider.enabled = false;
       
        ScoreAndGauge();

        Invoke("DestroyObstacle", destroyDelay);
    }

    private void DestroyObstacle()
    {
        ResettingObstacle();
        ObjectPool.ReturnObj(this.gameObject, (int)type.Type);
    }

    private void ResettingObstacle()
    {
        obstacleAnimator.SetBool("Attacked", false);
        obstacleCtrl.MoveSpeed = tempMoveSpeed;
        boxCollider.enabled = true;
        humansObj.SetActive(true);
        humanEffect.Reset(humanValue);
    }

    private void ScoreAndGauge()
    {
        if ((int)type.Type == 0)
        {
            GameManager.angerValue += 5;
            GameManager.score += 100;
        }
        else if ((int)type.Type == 1)
        {
            GameManager.angerValue += 15;
            GameManager.score += 450;
        }
    
        else if ((int)type.Type == 2)
        {
            GameManager.angerValue += 10;
            GameManager.score += 200;
        }
        
        else if ((int)type.Type == 3)
        {
            GameManager.angerValue += 20;
            GameManager.score += 700;

        }
        else if ((int)type.Type == 4)
        {
            GameManager.angerValue += 25;
            GameManager.score += 1300;
        }
        
    }
}
