﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uniboom : MonoBehaviour
{
    private static GameObject boomer;
    public static float _maxdistance = 40f;
    // Start is called before the first frame update
    void Start()
    {
        boomer = GameObject.Find("Boomerang");
    }
    
    public static void throwboomerang(float angle,float power)
    {
        Boomerang._maxdistance = _maxdistance;
        Boomerang._distancetogo =
            (power * _maxdistance > _maxdistance ? _maxdistance : power * _maxdistance);
        boomer.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        boomer.GetComponent<Rigidbody2D>().velocity = boomer.transform.up * 20f;
    }

    public static void returnboom()
    {
        boomer.GetComponent<Rigidbody2D>().velocity = boomer.GetComponent<Rigidbody2D>().velocity * -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject GO = other.gameObject;
        switch (GO.tag) // which object has it collided with 
        {
            case "Platform":
                boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                Boomerang._thrown = false;
                Boomerang.globalArrow.localScale = new Vector3(0f,0f,0f);
                break;
            case "Greenery":
                boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                Boomerang._thrown = false;
                Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
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
                break;
        }
    }
}
