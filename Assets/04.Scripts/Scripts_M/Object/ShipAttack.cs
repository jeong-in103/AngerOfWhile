using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ���� ���̽� ��ũ��Ʈ

public abstract class ShipAttack : ObjectData
{
    [SerializeField]
    protected Transform point; // ���� ������Ʈ ���� ��ġ

    // ���� ��Ÿ��
    [SerializeField]
    protected float MaxSpawnTime;
    protected float curSpawnTime;

    // ��Ÿ�� �ʱ�ȭ
    protected abstract void ResetSpawnTime();

    // ����
    protected abstract void Attack();
}
