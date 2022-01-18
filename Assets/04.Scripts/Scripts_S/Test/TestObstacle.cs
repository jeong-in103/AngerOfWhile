using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObstacle : MonoBehaviour
{
    public Ship ship;

    private float lifeTime;
    private float deadTime = 10f;

    public float acceleration = 7f;
    public Vector3 destination;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;

        if (lifeTime >= deadTime)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.smoothDeltaTime * ship.MoveSpeed * acceleration);
    }
}
