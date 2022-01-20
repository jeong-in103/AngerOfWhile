using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "Item")
        {
            Destroy(other.gameObject);
        }
    }
}
