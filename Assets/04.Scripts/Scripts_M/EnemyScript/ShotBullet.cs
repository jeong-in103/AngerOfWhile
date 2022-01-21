using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 배가 총을 발사하는 공격 방식 스크립트 

public class ShotBullet : ShipAttack
{
    private void Start()
    {
        ResetSpawnTime();
        curSpawnTime = MaxSpawnTime;
    }

    protected override void ResetSpawnTime()
    {
        MaxSpawnTime = 2f;
    }

    protected override void Attack()
    {
        Instantiate(type.BulletObject, point.position, Quaternion.identity);
    }
}
