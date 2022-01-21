using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            string ID = other.GetComponent<EnemyCtrl>().GetShipType();
            ObjectPool.ReturnObject(other.gameObject, ID);
        }
    }
}