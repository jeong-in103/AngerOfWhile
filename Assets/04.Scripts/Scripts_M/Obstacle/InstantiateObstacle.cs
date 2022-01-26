using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �谡 ������ ���� ������Ʈ�� ����� ���� ��� ��ũ��Ʈ

public class InstantiateObstacle : ObstacleData
{
    [SerializeField]
    private Transform point; // ���� ������Ʈ ���� ��ġ

    private int attackObjID; // ���� ������Ʈ ���̵�

    // ��Ÿ�� ���� ����
    private float maxSpawnTime;
    private float curSpawnTime;

    // ���� ��Ÿ�� ��
    [SerializeField]
    private float ranMinCoolTime;
    [SerializeField]
    private float ranMaxCoolTime;

    private bool isAttack;

    private void Awake()
    {
        attackObjID = (int)this.type.ObstacleObject.GetComponent<ObstacleCtrl>().GetObstacleType;
    }

    private void Start()
    {
        isAttack = false;

        ResetSpawnTime();
        curSpawnTime = 0;
    }

    private void Update()
    {
        if (maxSpawnTime <= curSpawnTime && isAttack == false)
        {
            Attack();
            isAttack = true;
        }
        else if(isAttack == false)
        {
            curSpawnTime += Time.deltaTime;
        }
    }

    private void ResetSpawnTime()
    {
        maxSpawnTime = Random.Range(ranMinCoolTime, ranMaxCoolTime);
    }

    private void Attack()
    {
        GameObject leaveObj = ObjectPool.GetObj(attackObjID);
        leaveObj.transform.position = point.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ObjectWall"))
        {
            isAttack = false;
        }
    }
}
