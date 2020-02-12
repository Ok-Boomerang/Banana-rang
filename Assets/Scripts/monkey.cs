using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkey : MonoBehaviour
{
    public Rigidbody2D monkey_rb;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            monkey_rb.MovePosition(monkey_rb.position + Vector2.left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            monkey_rb.MovePosition(monkey_rb.position + Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            monkey_rb.MovePosition(monkey_rb.position + Vector2.up * 1.5f );
        }
    }
}
