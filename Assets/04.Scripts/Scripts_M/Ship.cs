using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "New Object/Ship")]
public class Ship : ScriptableObject  // ��ũ���ͺ� ������Ʈ
{
    public enum ShipType  // �� ����
    {
        SHIP,
        SUB, 
        MOT, 
        HUNT, 
        NAVAL, 
    }

    [SerializeField]
    public ShipType type; // �� ����
    public ShipType Type { get { return type; } }

    [SerializeField] 
    private float moveSpeed; // �ӵ�
    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField]
    private float angerGauge; // �г������
    public float AngerGauge { get { return angerGauge; } }
}