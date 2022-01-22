using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPysics : MonoBehaviour
{
    
    private Rigidbody rig;

    private bool hit;

    [SerializeField]
    private float forcePower =2f;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (hit)
        {
            rig.AddForce(Vector3.up * forcePower, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            hit = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
