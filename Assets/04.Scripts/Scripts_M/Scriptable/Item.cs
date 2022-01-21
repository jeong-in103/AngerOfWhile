using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Object/Item")]
public class Item : ScriptableObject  // ��ũ���ͺ� ������Ʈ
{
    public enum ItemType  // ������ ����
    {
        LV1, 
        LV2,
        LV3,
        LV4,
        LV5, 
    }

    [SerializeField]
    private ItemType type; // ������ ����
    public ItemType Type { get { return type; } }

    [SerializeField]
    private float moveSpeed; // �ӵ�
    public float MoveSpeed { get { return moveSpeed; } }
}