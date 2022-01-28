using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections.LowLevel.Unsafe;

public class ObjectWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Item") || other.gameObject.layer == LayerMask.NameToLayer("Deco"))
        {
            int ID = UnsafeUtility.EnumToInt(other.GetComponent<ObstacleCtrl>().GetObstacleType);
            ObjectPool.ReturnObj(other.gameObject, ID);
        }
    }
}