using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAttacked : ObstacleData
{
    private Animator obstacleAnimator;
    private ObstacleCtrl obstacleCtrl;

    private BoxCollider boxCollider; //S

    [SerializeField]
    private float destroyDelay;

    [SerializeField]
    private bool testAttackedSwitch = false;

    private void OnEnable()
    {
        boxCollider.enabled = true; //S

    }
    private void Awake()
    {
        obstacleAnimator = gameObject.GetComponentInChildren<Animator>();
        obstacleCtrl = GetComponent<ObstacleCtrl>();
        boxCollider = GetComponent<BoxCollider>(); // S
    }

    private void Update()
    {
        if (testAttackedSwitch == true)
        {
            if (obstacleAnimator != null)
            {
                obstacleAnimator.SetTrigger("Attacked");
            }
            obstacleCtrl.MoveSpeed = 0f;
            this.gameObject.layer = 13;
            //점수 증가
            //분노 게이지 증가
            Invoke("DestroyObstacle", destroyDelay);
        }
    }

    public void Attacked()
    {
        if(obstacleCtrl.GetObstacleType == TypeID.SUB)
        {
            return;
        }

        if (obstacleAnimator != null)
        {
            obstacleAnimator.SetTrigger("Attacked");
        }
        obstacleCtrl.MoveSpeed = 0f;
        boxCollider.enabled = false;
                                     //점수 증가
                                     //분노 게이지 증가
        Invoke("DestroyObstacle", destroyDelay);
    }

    private void DestroyObstacle()
    {
        ObjectPool.ReturnObj(this.gameObject, (int)type.Type);
    }
}
