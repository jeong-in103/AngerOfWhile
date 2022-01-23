using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ���� ���̽� ��ũ��Ʈ

public abstract class ShipAttack : ObstacleData
{
    [SerializeField]
    protected Transform point; // ���� ������Ʈ ���� ��ġ
    [SerializeField]
    protected int attackObjID; // ���� ������Ʈ ���̵�

    // ���� ��Ÿ��
    [SerializeField]
    protected float MaxSpawnTime;
    protected float curSpawnTime;

    protected virtual void Start()
    {
        attackObjID = (int)this.type.ObstacleObject.GetComponent<ObstacleCtrl>().GetObstacleType;
    }

    // ��Ÿ�� �ʱ�ȭ
    protected abstract void ResetSpawnTime();

    // ����
    protected abstract void Attack();
}
