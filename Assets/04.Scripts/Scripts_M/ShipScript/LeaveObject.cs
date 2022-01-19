using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 배가 지나간 곳에 오브젝트를 남기는 공격 방식 스크립트

public class LeaveObject : ShipAttack
{
    private void Start()
    {
        ResetSpawnTime();
        curSpawnTime = MaxSpawnTime;
    }

    protected override void ResetSpawnTime()
    {
        MaxSpawnTime = Random.Range(0.5f, 1.5f);
    }

    protected override void Attack()
    {
        Instantiate(type.LeaveObject, point.position, Quaternion.identity);
    }
}
