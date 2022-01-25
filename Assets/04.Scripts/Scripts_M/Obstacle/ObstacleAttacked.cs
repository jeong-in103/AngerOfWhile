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
    private int humanValue;

    [SerializeField]
    private float destroyDelay;

    [SerializeField]
    private bool testAttackedSwitch = false;

    private void Awake()
    {
        obstacleAnimator = gameObject.GetComponentInChildren<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        obstacleCtrl = GetComponent<ObstacleCtrl>();
        humanEffect = GetComponentInChildren<HumanExplosion>();
    }

    private void Update()
    {
        //test �� �ڵ�
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
            obstacleCtrl.MoveSpeed = 0f;
            boxCollider.enabled = false;
            //���� ����
           
            //�г� ������ ����

            Invoke("DestroyObstacle", destroyDelay);
        }
    }

    public void Attacked()
    {
        if (obstacleAnimator != null)
        {
            obstacleAnimator.SetTrigger("Attacked");
        }

        if (humanEffect == true)
        {
            humanEffect.ExpHuman(humanValue);
        }
        obstacleCtrl.MoveSpeed = 0f;
        boxCollider.enabled = false;
       
        ScoreAndGauge();

        Invoke("DestroyObstacle", destroyDelay);
    }

    private void DestroyObstacle()
    {
        ObjectPool.ReturnObj(this.gameObject, (int)type.Type);
    }

    private void ScoreAndGauge()
    {
        if ((int)type.Type == 0)
        {            
           GameObject.Find("GameManager").GetComponent<GameManager_G>().angerSlider.value += 5;
           GameObject.Find("GameManager").GetComponent<GameManager_G>().score += 100;
        }
        else if ((int)type.Type == 1)
        {
            GameObject.Find("GameManager").GetComponent<GameManager_G>().angerSlider.value += 15;
            GameObject.Find("GameManager").GetComponent<GameManager_G>().score += 450;
        }
    
        else if ((int)type.Type == 2)
        {
            GameObject.Find("GameManager").GetComponent<GameManager_G>().angerSlider.value += 10;
        GameObject.Find("GameManager").GetComponent<GameManager_G>().score += 200;
        }
        
        else if ((int)type.Type == 3)
        {
            GameObject.Find("GameManager").GetComponent<GameManager_G>().angerSlider.value += 20;
            GameObject.Find("GameManager").GetComponent<GameManager_G>().score += 700;

        }
        else if ((int)type.Type == 4)
        {
            GameObject.Find("GameManager").GetComponent<GameManager_G>().angerSlider.value += 25;
             GameObject.Find("GameManager").GetComponent<GameManager_G>().score += 1300;
        }
        
    }
}
