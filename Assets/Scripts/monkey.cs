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
    private void OnCollisionEnter2D(Collision2D other)
        {
            GameObject GO = other.gameObject;
            switch (GO.tag) // which object has it collided with 
            {
                case "SingleBanana": // ignore this collision and implement no phyisics
                case "MultiBanana":
                    Physics2D.IgnoreCollision(GO.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
                    break;
                case "Platform":
                    //Debug.Log("Platform object");
                    break;
                case "Greenery":
                    //Debug.Log("Greenery object");
                    break;
                default:
                    break;
            }
    
        }
}
