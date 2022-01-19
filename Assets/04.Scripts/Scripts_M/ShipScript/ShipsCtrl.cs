using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsCtrl : ShipData
{
    [SerializeField]
    private float standardSpeed; // ���� �ӵ�

    private void Update()
    {
        ShipMoving();
    }

    protected void ShipMoving() // �� �̵�
    {
        //�̵�
        this.transform.Translate(Vector3.back * Time.deltaTime * standardSpeed * type.MoveSpeed);
    }
}
