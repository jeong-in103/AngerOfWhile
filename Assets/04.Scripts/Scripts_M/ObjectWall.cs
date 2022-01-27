using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enmey") || other.gameObject.layer == LayerMask.NameToLayer("Item") || other.gameObject.layer == LayerMask.NameToLayer("Deco"))
        {
            int ID = (int)other.GetComponent<ObstacleCtrl>().GetObstacleType;
            ObjectPool.ReturnObj(other.gameObject, ID);
        }
    }
}