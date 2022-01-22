using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : ObjectData
{
    [SerializeField]
    private float moveSpeed; // ���� �ӵ�

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

    protected void ShipMoving() // �� �̵�
    {
        //�̵�
        objTr.Translate(Vector3.back * Time.deltaTime * moveSpeed);
    }
}
