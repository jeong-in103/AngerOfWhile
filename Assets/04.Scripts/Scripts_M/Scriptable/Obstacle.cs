using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "New Object/Object")]
public class Obstacle : ScriptableObject  // 스크립터블 오브젝트
{
    [SerializeField]
    private TypeID type; // 배 유형
    public TypeID Type { get { return type; } }

    [SerializeField]
    private float angerGauge; // 분노게이지
    public float AngerGauge { get { return angerGauge; } }

    [SerializeField]
    private int score; // 추가 점수
    public int Score { get { return score; } }

    [SerializeField]
    private GameObject obstacleObject; // 배가 생성하는 장애물
    public GameObject ObstacleObject { get { return obstacleObject; } }
}