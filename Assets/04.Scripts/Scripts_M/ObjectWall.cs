using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            int ID = (int)other.GetComponent<ObjectCtrl>().GetObjectType();
            ObjectPool.ReturnObj(other.gameObject, ID);
        }
    }
}