using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �谡 ���� �߻��ϴ� ���� ��� ��ũ��Ʈ 

public class ShotBullet : ShipAttack
{
    protected override void Start()
    {
        base.Start();

        ResetSpawnTime();
        curSpawnTime = MaxSpawnTime;
    }

    private void Update()
    {
        if (MaxSpawnTime <= curSpawnTime)
        {
            Attack();
            ResetSpawnTime();
            curSpawnTime = -100f;
        }
        else
        {
            curSpawnTime += Time.deltaTime;
        }
    }

    protected override void ResetSpawnTime()
    {
        MaxSpawnTime = 2f;
    }

    protected override void Attack()
    {
        GameObject bulletObj = ObjectPool.GetObj(attackObjID);
        bulletObj.transform.position = point.position;
    }
}
