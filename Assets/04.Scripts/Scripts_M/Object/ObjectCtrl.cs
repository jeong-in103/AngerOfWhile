using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : ObjectData
{
    [SerializeField]
    private float moveSpeed; // 기준 속도

    private Transform objTr;

    private void Start()
    {
        objTr = GetComponent<Transform>();
    }

    public string GetObjectType()
    {
        return type.Type;
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
