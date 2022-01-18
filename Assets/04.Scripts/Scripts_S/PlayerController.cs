using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Componet
    public Movement movement; //Player Move Script

    // Variable
    public float moveSpeed; // Player Move Speed
    public int hp = 3; //Player HP

    private void Update()
    {
        LimitMove();
    }
    private void FixedUpdate()
    {
        Move();
        PCMove();
    }

    // @S Player 이동 
    private void Move()
    {
        if (movement.MoveDirect != Vector2.zero)
        {
            if (movement.MoveDirect.x > 0f)
            {
                transform.position += Vector3.right * Time.deltaTime * moveSpeed;
            }
            else if (movement.MoveDirect.x < 0f)
            {
                transform.position += Vector3.left * Time.deltaTime * moveSpeed;
            }
        }
    }
    // @S : 개발 PC용 움직임
    private void PCMove()
    {
        float x = Input.GetAxis("Horizontal");

        if (x > 0f)
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
        else if (x < 0f)
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
    }
    // @S : Player가 카메라 화면밖으로 나가지 않도록
    private void LimitMove()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.1f) pos.x = 0.1f;
        if (pos.x > 0.9f) pos.x = 0.9f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
