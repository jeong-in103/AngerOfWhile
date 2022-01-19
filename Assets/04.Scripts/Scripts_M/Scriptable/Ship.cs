using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "New Object/Ship")]
public class Ship : ScriptableObject  // 스크립터블 오브젝트
{
    [SerializeField] 
    private float moveSpeed; // 속도
    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField]
    private float angerGauge; // 분노게이지
    public float AngerGauge { get { return angerGauge; } }

    [SerializeField]
    private float score; // 추가 점수
    public float Score { get { return score; } }

    [SerializeField]
    private GameObject leaveObject; // 배가 남기고 가는 오브젝트
    public GameObject LeaveObject { get { return leaveObject; } }

    [SerializeField]
    private GameObject bulletObject; // 배가 발사하는 총알 오브젝트
    public GameObject BulletObject { get { return bulletObject; } }
}