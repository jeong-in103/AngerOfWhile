using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ���� ���̽� ��ũ��Ʈ

public abstract class ShipAttack : EnemyData
{
    [SerializeField]
    protected Transform point; // ���� ������Ʈ ���� ��ġ

    // ���� ��Ÿ��
    [SerializeField]
    protected float MaxSpawnTime;
    protected float curSpawnTime;

    private void Update()
    {
        curSpawnTime += Time.deltaTime;
        if (MaxSpawnTime <= curSpawnTime)
        {
            Attack();
            ResetSpawnTime();
            curSpawnTime = 0;
        }
    }

    // ��Ÿ�� �ʱ�ȭ
    protected abstract void ResetSpawnTime();

    // ����
    protected abstract void Attack();
}
