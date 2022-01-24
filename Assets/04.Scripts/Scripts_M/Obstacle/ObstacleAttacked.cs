using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAttacked : ObstacleData
{
    private Animator obstacleAnimator;
    private ObstacleCtrl obstacleCtrl;

    [SerializeField]
    private float destroyDelay;

    [SerializeField]
    private bool testAttackedSwitch = false;

    private void Awake()
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
            //���� ����
            //�г� ������ ����
            Invoke("DestroyObstacle", destroyDelay);
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
            //���� ����
            //�г� ������ ����
            Invoke("DestroyObstacle", destroyDelay);
        }
    }

    private void DestroyObstacle()
    {
        ObjectPool.ReturnObj(this.gameObject, (int)type.Type);
    }
}
