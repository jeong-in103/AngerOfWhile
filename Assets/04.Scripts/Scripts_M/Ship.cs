using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "New Object/Ship")]
public class Ship : ScriptableObject  // 스크립터블 오브젝트
{
    public enum ShipType  // 배 유형
    {
        SHIP,
        SUB, 
        MOT, 
        HUNT, 
        NAVAL, 
    }

    [SerializeField]
    public ShipType type; // 배 유형
    public ShipType Type { get { return type; } }

    [SerializeField] 
    private float moveSpeed; // 속도
    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField]
    private float angerGauge; // 분노게이지
    public float AngerGauge { get { return angerGauge; } }
}