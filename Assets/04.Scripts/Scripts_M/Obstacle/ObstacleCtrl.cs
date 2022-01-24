using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCtrl : ObstacleData
{
    public TypeID GetObstacleType { get { return type.Type; } }

    [SerializeField]
    private float moveSpeed; // 기준 속도
    public float MoveSpeed { set { moveSpeed = value; } }

    private Transform objTr;

    private void Awake()
    {
        objTr = GetComponent<Transform>();
    }

    private void Update()
    {
        ShipMoving();
    }

    protected void ShipMoving() // 배 이동
    {
        //이동
        objTr.Translate(Vector3.back * Time.deltaTime * moveSpeed);
    }
}
