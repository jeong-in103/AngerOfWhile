using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Componet
    public Movement movement; // Player Move Interface UI 

    //Variable
    public float moveSpeed; // Player Move Speed


    private void FixedUpdate()
    {
        Move();
    }

    // @S Player ¿Ãµø 
    private void Move()
    {
        if (movement.LeftMove())
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
        else if (movement.RightMove())
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
    }
}
