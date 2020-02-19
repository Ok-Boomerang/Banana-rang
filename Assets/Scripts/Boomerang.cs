using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boomerang : MonoBehaviour
{
    public Rigidbody2D _boom_rb;
    private bool _thrown; //has the boomerang been thrown yet?
    private float _maxdistance = 40f; // farthers distance it should travel
    public Transform _home; // where the boomerang returns too
    private bool _forward = true; // is it in a forward or backward motion
    private Vector3 _distancereleased; // the distance it has traveled so far
    private Vector2 _lookdirection;
    private float _lookAngle;
    private float _clickStart;
    private float _power;
    private float _distancetogo;
    private bool _clicked;
    private void Start()
    {
        _boom_rb = gameObject.GetComponent<Rigidbody2D>();
        _home = GameObject.Find("MonkeyHand").transform;
    }

    void Update()
    {
        if (BoomerangManager.boomerangsLeft > 0)
        {
            _lookdirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            _lookAngle = Mathf.Atan2(_lookdirection.y, _lookdirection.x) * Mathf.Rad2Deg;
            if (!_thrown)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _clicked = true;
                    _clickStart = Time.time;
                    GameObject.Find("Monkey").GetComponent<monkey>()._mousedown = true;
                }

                if (Input.GetMouseButtonUp(0) & _clicked)
                {
                    _clicked = false;
                    _power = Time.time - _clickStart;
                    _distancetogo = (_power * _maxdistance > _maxdistance ? _maxdistance : _power * _maxdistance);
                    _thrown = true;
                    _distancereleased = transform.position;
                    transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle - 90f);
                    _boom_rb.velocity = transform.up * 20f;
                    GameObject.Find("Monkey").GetComponent<monkey>()._mousedown = false;
                    BoomerangManager.boomerangsLeft -= 1;
                }
            }
            else if (_thrown)
            {
                transform.Rotate(0, 0, 1100 * Time.deltaTime);
                if (_forward & Vector3.Distance(_distancereleased, transform.position) >= _distancetogo)
                {
                    _forward = false;
                    _boom_rb.velocity = _boom_rb.velocity * -1;
                }
                else if (!_forward & Vector3.Distance(_distancereleased, transform.position) <= 1f)
                {
                    _thrown = false;
                    _forward = true;
                }
            }
        }
        else
        {
            BoomerangManager.boomerangsLeft = 5;
            ScoreManager.Score = 0;
            SceneManager.LoadScene(3);
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
