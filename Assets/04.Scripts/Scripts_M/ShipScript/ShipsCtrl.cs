using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsCtrl : ShipData
{
    [SerializeField]
    private float standardSpeed; // 기준 속도

    private void Update()
    {
        ShipMoving();
    }

    protected void ShipMoving() // 배 이동
    {
        //이동
        this.transform.Translate(Vector3.back * Time.deltaTime * standardSpeed * type.MoveSpeed);
    }
}
