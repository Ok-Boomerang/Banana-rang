﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIboom : MonoBehaviour
{
    private static GameObject boomer;
    public static float _maxdistance = 40f;
    private static bool rets = false;
    // Start is called before the first frame update
    void Start()
    {
        boomer = GameObject.Find("Boomerang");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void throwboomerang(float angle,float power)
    {//change 
        rets = false;
        Boomerang._maxdistance = _maxdistance;
        Boomerang._distancetogo =
            (power * _maxdistance > _maxdistance ? _maxdistance : power * _maxdistance);
        boomer.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        boomer.GetComponent<Rigidbody2D>().velocity = boomer.transform.up * 20f;
    }

    public static void returnboom()
    { //change 
        rets = true;
        Vector2 change = new Vector2(boomer.GetComponent<Rigidbody2D>().velocity.x * -1,
            boomer.GetComponent<Rigidbody2D>().velocity.y* 0.5f);
        boomer.GetComponent<Rigidbody2D>().velocity = change;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject GO = other.gameObject;
        switch (GO.tag) // which object has it collided with 
        {
            case "Platform":
                Debug.Log("Platform object");
                boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                Boomerang._thrown = false;
                Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
                if (rets)
                {
                    Boomerang._forward = true;
                }
                break;
            case "Greenery":
                boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                Boomerang._thrown = false;
                Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
                if (rets)
                {
                    Boomerang._forward = true;
                }
                break;
            case "Water":
                boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                Boomerang._thrown = false;
                Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
                break;
            case "HorizontalPlatform":

                boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                Boomerang._thrown = false;
                Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
                if (rets)
                {
                    Boomerang._forward = true;
                }
                break;
        }
    }

}
