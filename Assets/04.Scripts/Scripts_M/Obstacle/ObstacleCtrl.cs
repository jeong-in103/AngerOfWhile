using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCtrl : ObstacleData
{
    public TypeID GetObstacleType { get { return type.Type; } }

    [SerializeField]
    private float moveSpeed; // ���� �ӵ�
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

    protected void ShipMoving() // �� �̵�
    {
        //�̵�
        objTr.Translate(Vector3.back * Time.deltaTime * moveSpeed);
    }
}
