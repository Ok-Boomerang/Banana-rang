using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkey : MonoBehaviour
{
    public Rigidbody2D monkey_rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }
}
