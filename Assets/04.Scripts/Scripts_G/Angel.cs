using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    private Rigidbody angelRb;
    // Start is called before the first frame update
   void Start()
   {
        angelRb = GetComponent<Rigidbody>();
   }

   
    void OnTriggerStay(Collider other)
    {
        angelRb.AddForce(Vector3.up * 12.0f, ForceMode.Acceleration);
        
    }
}
