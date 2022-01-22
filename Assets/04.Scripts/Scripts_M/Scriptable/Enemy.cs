using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "New Object/Enemy")]
public class Enemy : ScriptableObject  // ��ũ���ͺ� ������Ʈ
{
    [SerializeField]
    private string type; // �� ����
    public string Type { get { return type; } }

    [SerializeField]
    private float angerGauge; // �г������
    public float AngerGauge { get { return angerGauge; } }

    [SerializeField]
    private float score; // �߰� ����
    public float Score { get { return score; } }

    [SerializeField]
    private GameObject leaveObject; // �谡 ����� ���� ������Ʈ
    public GameObject LeaveObject { get { return leaveObject; } }

    [SerializeField]
    private GameObject bulletObject; // �谡 �߻��ϴ� �Ѿ� ������Ʈ
    public GameObject BulletObject { get { return bulletObject; } }
}