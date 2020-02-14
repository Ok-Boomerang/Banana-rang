using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public Rigidbody2D _boom_rb;
    private bool _thrown = false; //has the boomerang been thrown yet?
    public float _maxdistance; // farthers distance it should travel
    public Transform _home; // where the boomerang returns too
    private bool _forward = true; // is it in a forward or backward motion
    private Vector3 _distancereleased; // the distance it has traveled so far
    private Vector2 _lookdirection;
    private float _lookAngle;
    private float _clickStart;
    private float _power;
    private float _distancetogo;
    private void Start()
    {
        _boom_rb = gameObject.GetComponent<Rigidbody2D>();
        _home = GameObject.Find("MonkeyHand").transform;
        _maxdistance = 40f;
    }

    void Update()
    {

        _lookdirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _lookAngle = Mathf.Atan2(_lookdirection.y, _lookdirection.x) * Mathf.Rad2Deg;
        if (!_thrown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _clickStart = Time.time;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _power = Time.time - _clickStart;
                _distancetogo = ( _power * _maxdistance > _maxdistance ? _maxdistance : _power * _maxdistance );
                _thrown = true;
                _distancereleased = transform.position;
                transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle - 90f);
                _boom_rb.velocity = transform.up * 20f;
            }
        }
        else if (_thrown)
        {
            transform.Rotate (0,0,1100*Time.deltaTime);
            if (_forward & Vector3.Distance(_distancereleased, transform.position) >= _distancetogo )
            {
                _forward = false;
                _boom_rb.velocity = _boom_rb.velocity * -1 ;
            }
            else if (!_forward & Vector3.Distance(_distancereleased, transform.position) <= 1f)
            {
                _thrown = false;
                _forward = true;
            }
        }
    }
    
    private void LateUpdate()
    {
        if (!_thrown) 
        { SetInHand(); }
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
                //Debug.Log("Default Case, no know tag");
                break;
        }

    }

}
