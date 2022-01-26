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

    [SerializeField]
    private GameObject humansObj;

    [SerializeField]
    private int humanValue;

    [SerializeField]
    private float destroyDelay;
    private float tempMoveSpeed;

    [SerializeField]
    private bool testAttackedSwitch = false;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        obstacleCtrl = GetComponent<ObstacleCtrl>();
        obstacleAnimator = GetComponentInChildren<Animator>();
        humanEffect = GetComponentInChildren<HumanExplosion>();
    }

    private void Update()
    {
        if(testAttackedSwitch == true)
        {
            testAttackedSwitch = false;

            if (obstacleAnimator != null)
            {
                obstacleAnimator.SetBool("Attacked", true);
            }
            else if (type.Type == TypeID.OIL)
            {
                GetComponentInChildren<MeshRenderer>().material = oilRemoveMaterial;
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
    }

    public void Attacked()
    {
        if (obstacleAnimator != null)
        {
            obstacleAnimator.SetBool("Attacked", true);
        }
        else if(type.Type == TypeID.OIL)
        {
            GetComponentInChildren<MeshRenderer>().material = oilRemoveMaterial;
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
        ObjectPool.ReturnObj(this.gameObject, (int)type.Type);
        ResettingObstacle();
    }

    private void ResettingObstacle()
    {
        
        obstacleCtrl.MoveSpeed = tempMoveSpeed;
        boxCollider.enabled = true;

        if(obstacleAnimator == true)
        {
            obstacleAnimator.SetBool("Attacked", false);
        }
        else if(type.Type == TypeID.OIL)
        {
            GetComponentInChildren<MeshRenderer>().material = oilMaterial;
        }

        if(humansObj == true)
        {
            humansObj.SetActive(true);
        }

        if(humanEffect == true)
        {
            humanEffect.Reset(humanValue);
        }
    }

    private void ScoreAndGauge()
    {
        GameManager.angerValue += type.AngerGauge;
        GameManager.score += type.Score;

        //if ((int)type.Type == 0)
        //{
        //    GameManager.angerValue += 5;
        //    GameManager.score += 100;
        //}
        //else if ((int)type.Type == 1)
        //{
        //    GameManager.angerValue += 15;
        //    GameManager.score += 450;
        //}
    
        //else if ((int)type.Type == 2)
        //{
        //    GameManager.angerValue += 10;
        //    GameManager.score += 200;
        //}
        
        //else if ((int)type.Type == 3)
        //{
        //    GameManager.angerValue += 20;
        //    GameManager.score += 700;

        //}
        //else if ((int)type.Type == 4)
        //{
        //    GameManager.angerValue += 25;
        //    GameManager.score += 1300;
        //}
        
    }
}
