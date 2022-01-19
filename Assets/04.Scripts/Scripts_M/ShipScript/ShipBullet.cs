using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Update()
    {
        this.transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
