using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadboom : MonoBehaviour
{
    private static GameObject boomer;
    public static float _maxdistance = 40f;
    private static float grav = .1f;
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
        grav = .1f;
        Boomerang._maxdistance = _maxdistance;
        Boomerang._distancetogo =
            (power * _maxdistance > _maxdistance ? _maxdistance : power * _maxdistance);
        boomer.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        boomer.GetComponent<Rigidbody2D>().velocity = boomer.transform.up * power * 30f;
    }

    public static void gravity()
    {
        Vector2 change = new Vector2(boomer.GetComponent<Rigidbody2D>().velocity.x,
            boomer.GetComponent<Rigidbody2D>().velocity.y - grav);
        boomer.GetComponent<Rigidbody2D>().velocity = change;
    }

    public static void returnboom()
    {//change
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
                Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
                break;
            case "Greenery":
                boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                Boomerang._thrown = false;
                Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
                break;
            case "Water":
                grav = .8f;
                break;
        }
    }
}
