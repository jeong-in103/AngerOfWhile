using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Object/Item")]
public class Item : ScriptableObject  // 스크립터블 오브젝트
{
    public enum ItemType  // 아이템 유형
    {
        LV1, 
        LV2,
        LV3,
        LV4,
        LV5, 
    }

    [SerializeField]
    private ItemType type; // 아이템 유형
    public ItemType Type { get { return type; } }

    [SerializeField]
    private float moveSpeed; // 속도
    public float MoveSpeed { get { return moveSpeed; } }
}