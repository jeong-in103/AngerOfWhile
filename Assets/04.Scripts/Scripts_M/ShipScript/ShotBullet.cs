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
        MaxSpawnTime = Random.Range(0.5f, 1.5f);
    }

    protected override void Attack()
    {
        Instantiate(type.BulletObject, point.position, Quaternion.identity);
    }
}
