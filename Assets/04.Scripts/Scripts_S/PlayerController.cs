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

    // @S Player �̵� 
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
    // @S : ���� PC�� ������
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
    // @S : Player�� ī�޶� ȭ������� ������ �ʵ���
    private void LimitMove()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.1f) pos.x = 0.1f;
        if (pos.x > 0.9f) pos.x = 0.9f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
