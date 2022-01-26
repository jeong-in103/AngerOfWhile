using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "New Object/Object")]
public class Obstacle : ScriptableObject  // ��ũ���ͺ� ������Ʈ
{
    [SerializeField]
    private TypeID type; // �� ����
    public TypeID Type { get { return type; } }

    [SerializeField]
    private float angerGauge; // �г������
    public float AngerGauge { get { return angerGauge; } }

    [SerializeField]
    private int score; // �߰� ����
    public int Score { get { return score; } }

    [SerializeField]
    private GameObject obstacleObject; // �谡 �����ϴ� ��ֹ�
    public GameObject ObstacleObject { get { return obstacleObject; } }
}