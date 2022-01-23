using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAttacked : ObstacleData
{
    private Animator obstacleAnimator;
    private ObstacleCtrl obstacleCtrl;

    [SerializeField]
    private bool testAttackedSwitch = false;

    private void Start()
    {
        obstacleAnimator = gameObject.GetComponentInChildren<Animator>();
        obstacleCtrl = GetComponent<ObstacleCtrl>();
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
            Invoke("DestroyObstacle", 5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (obstacleAnimator != null)
            {
                obstacleAnimator.SetTrigger("Attacked");
            }
            obstacleCtrl.MoveSpeed = 0f;
            this.gameObject.layer = 13;
            //점수 증가
            //분노 게이지 증가
            Invoke("DestroyObstacle", 5f);
        }
    }

    private void DestroyObstacle()
    {
        ObjectPool.ReturnObj(this.gameObject, (int)type.Type);
    }
}
