using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 배가 지나간 곳에 오브젝트를 남기는 공격 방식 스크립트

public class InstantiateObstacle : ObstacleData
{
    [SerializeField]
    private Transform point; // 공격 오브젝트 생성 위치

    private int attackObjID; // 공격 오브젝트 아이디

    // 쿨타임 관리 변수
    private float maxSpawnTime;
    private float curSpawnTime;

    // 공격 쿨타임 값
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
