using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : EnemyData
{
    [SerializeField]
    private float standardSpeed; // ���� �ӵ�

    private Transform enemyTr;

    private void Start()
    {
        enemyTr = GetComponent<Transform>();
    }

    public string GetShipType()
    {
        return type.Type;
    }

    private void Update()
    {
        ShipMoving();
    }

    protected void ShipMoving() // �� �̵�
    {
        //�̵�
        enemyTr.Translate(Vector3.back * Time.deltaTime * standardSpeed * type.MoveSpeed);
    }
}
