using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class monkey : MonoBehaviour
{
    private Rigidbody2D monkeyRB;
    // movement vars 
    private float _speed;
    private bool _up;
    private bool _left;
    private bool _right;
    private bool _jumped;

    private float _jumpspeed;
    // end of movement vars
    
    // vars for restricting the monkeys location 
    public Camera monkeybounds;
    private float _objectWidth;
    private float _objectHeight;
    private Vector2 _screenposition;
    private float _halfHeight;
    private float _halfWidth;
    // end of boundary vars 
    
    void Start ()
    {
        _speed = 4f;
        _jumped = false;
        // retrieving 
        foreach (Camera c in Camera.allCameras) 
        { if (c.name == "monkeybounds") {
            monkeybounds = c; } }

        monkeyRB = gameObject.GetComponent<Rigidbody2D>();
        _jumpspeed = 350f;
        _halfHeight = monkeybounds.orthographicSize;
        _halfWidth = monkeybounds.aspect * _halfHeight;
        _screenposition = monkeybounds.transform.position;
        _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        _objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }
    void Update()
    {
        _up = Input.GetKey(KeyCode.W);
        _right = Input.GetKey(KeyCode.D);
        _left = Input.GetKey(KeyCode.A);
        
        if (_up & !_jumped)
        {
            _jumped = true;
            monkeyRB.AddForce(Vector2.up * _jumpspeed, ForceMode2D.Force);
        }

        if (_right != _left)
        {
            if (_right)
            {
                transform.position += Time.deltaTime * _speed * Vector3.right;
            }
            else if (_left)
            {
                transform.position += Time.deltaTime * _speed * Vector3.left;
            }
        }
    }
    
    // check the bounds of monkey 
    void LateUpdate(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _screenposition.x - _halfWidth + _objectWidth, _screenposition.x + _halfWidth - _objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, _screenposition.y - _halfHeight + _objectHeight, _screenposition.y + _halfHeight - _objectHeight);
        transform.position = viewPos;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject GO = other.gameObject;
        switch (GO.tag) // which object has it collided with 
        {
            case "mushroom": // ignore this collision and implement no phyisics
                _jumpspeed = 200f;
                _jumped = false;
                break;
            case "Platform":
                _jumpspeed = 400f;
                _jumped = false;
                break;
        }

    }
}
