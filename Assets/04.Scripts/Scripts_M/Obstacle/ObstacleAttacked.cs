using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //���� ����
        //�г� ������ ����
        Invoke("DestroyObstacle", destroyDelay);
    }

    private void DestroyObstacle()
    {
        ObjectPool.ReturnObj(this.gameObject, (int)type.Type);
    }
}
