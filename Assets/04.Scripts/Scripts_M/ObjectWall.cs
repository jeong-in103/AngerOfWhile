using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Item") || other.CompareTag("Deco"))
        {
            int ID = (int)other.GetComponent<ObstacleCtrl>().GetObstacleType;
            ObjectPool.ReturnObj(other.gameObject, ID);
        }
    }
}