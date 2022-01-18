using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObstacle : MonoBehaviour
{
    public Ship ship;

    private float lifeTime;
    private float deadTime = 3f;

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
        transform.position = Vector3.Lerp(transform.position, destination, Time.smoothDeltaTime * ship.MoveSpeed *0.5f);
    }
}
