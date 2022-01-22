using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "New Object/Object")]
public class Object : ScriptableObject  // ��ũ���ͺ� ������Ʈ
{
    [SerializeField]
    private TypeID type; // �� ����
    public TypeID Type { get { return type; } }

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