using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �谡 ������ ���� ������Ʈ�� ����� ���� ��� ��ũ��Ʈ

public class LeaveObject : ShipAttack
{
    private bool isAttack;

    private void Start()
    {
        attackObjID = (int)type.LeaveObject.GetComponent<ObjectCtrl>().GetObjectType();
        isAttack = false;

        ResetSpawnTime();
        curSpawnTime = 0;
    }

    private void Update()
    {
        if (MaxSpawnTime <= curSpawnTime && isAttack == false)
        {
            Attack();
            isAttack = true;
        }
        else if(isAttack == false)
        {
            curSpawnTime += Time.deltaTime;
        }
    }

    protected override void ResetSpawnTime()
    {
        MaxSpawnTime = Random.Range(3f, 4f);
    }

    protected override void Attack()
    {
        GameObject leaveObj = ObjectPool.GetObj(attackObjID);
        leaveObj.transform.position = point.position;
    }
}
