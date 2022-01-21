using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �谡 ���� �߻��ϴ� ���� ��� ��ũ��Ʈ 

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
