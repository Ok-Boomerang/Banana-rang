using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public Rigidbody2D _boom_rb;
    private bool _thrown; //has the boomerang been thrown yet?
    private float _maxdistance; // farthers distance it should travel
    public Transform _home; // where the boomerang returns too
    private float _speed; // speed of boomerang
    private bool _forward; // is it in a forward or backward motion
    private float _travel; // the distance it should be traveling in an update
    private float _currdistance; // the distance it has traveled so far

    private void Start()
    {
        _boom_rb = gameObject.GetComponent<Rigidbody2D>();
        _thrown = false;
        _home = GameObject.Find("MonkeyHand").transform;
        _maxdistance = 20f;
        _speed = 15f;
        _forward = true;
        _travel = 0f;
        _currdistance = 0f;

    }

    void Update()
    {
        if (!_thrown)
        {
            SetInHand();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _thrown = true;
            }
        }
        else
        {
            _travel = Time.deltaTime * _speed;
            transform.Rotate (0,0,1020*Time.deltaTime); // adding rotation to the boomerang; 
            if (_forward)
            {
                _currdistance += _travel;
                _boom_rb.MovePosition(_boom_rb.position + Vector2.right * _travel);
                if (_currdistance >= _maxdistance)
                {
                    _forward = false;
                }
            }
            else
            {
                _currdistance -= _travel;
                _boom_rb.MovePosition(_boom_rb.position + Vector2.left * _travel);
                if (_currdistance <= 0f)
                {
                    _forward = true;
                    _thrown = false;
                }
            }
        }
    }
    public void SetInHand()
    {
        transform.position = _home.position;
        transform.rotation = _home.rotation;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject GO = other.gameObject;
        switch (GO.tag) // which object has it collided with 
        {
            case "Monkey": // ignore this collision and implement no phyisics
                Physics2D.IgnoreCollision(GO.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
                break;
            case "SingleBanana":
                //Debug.Log("SingleBanana object");
                break;
            case "MultiBanana":
                //Debug.Log("MultiBanana object");
                break;
            case "Platform":
                Debug.Log("Platform object");
                break;
            case "Greenery":
                //Debug.Log("Greenery object");
                break;
            default:
                Debug.Log("Default Case, no know tag");
                break;
        }

    }

}
