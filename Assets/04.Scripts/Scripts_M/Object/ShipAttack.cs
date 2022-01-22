using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 배 공격 베이스 스크립트

public abstract class ShipAttack : ObjectData
{
    [SerializeField]
    protected Transform point; // 공격 오브젝트 생성 위치
    [SerializeField]
    protected int attackObjID; // 공격 오브젝트 아이디

    // 공격 쿨타임
    [SerializeField]
    protected float MaxSpawnTime;
    protected float curSpawnTime;

    // 쿨타임 초기화
    protected abstract void ResetSpawnTime();

    // 공격
    protected abstract void Attack();
}
