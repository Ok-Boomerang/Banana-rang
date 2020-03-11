using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncyboom : MonoBehaviour
{
    private static GameObject boomer;
    public static float _maxdistance = 40f;
    public static int numBounces = 0;

    public static int bounceDir = 1;
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
        numBounces = 0;
        Boomerang._maxdistance = _maxdistance;
        Boomerang._distancetogo =
            (power * _maxdistance > _maxdistance ? _maxdistance : power * _maxdistance);
        boomer.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        boomer.GetComponent<Rigidbody2D>().velocity = boomer.transform.up * 20f;
    }

    public static void returnboom()
    {//change
        boomer.GetComponent<Rigidbody2D>().velocity = boomer.GetComponent<Rigidbody2D>().velocity * -1;
    }

    public static void bounceHorizontal()
    {
        Vector2 change = new Vector2(boomer.GetComponent<Rigidbody2D>().velocity.x,
            boomer.GetComponent<Rigidbody2D>().velocity.y * -1);
        boomer.GetComponent<Rigidbody2D>().velocity = change;
    }

    public static void bounceVertical()
    {
        Vector2 change = new Vector2(boomer.GetComponent<Rigidbody2D>().velocity.x * -1,
            boomer.GetComponent<Rigidbody2D>().velocity.y);
        boomer.GetComponent<Rigidbody2D>().velocity = change;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject GO = other.gameObject;
        switch (GO.tag) // which object has it collided with 
        {
            case "HorizontalPlatform":
                if(numBounces < 4) 
                {
                    bounceHorizontal();
                    numBounces += 1;
                    bounceDir *= -1;
                }
                else
                {
                    boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                    Boomerang._thrown = false;
                    Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
                }
                break;
            case "VerticalPlatform":
                if(numBounces < 4) 
                {
                    bounceVertical();
                    numBounces += 1;
                    bounceDir *= -1;
                }
                else
                {
                    boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                    Boomerang._thrown = false;
                    Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
                }
                break;
            case "Grass":
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
                boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                Boomerang._thrown = false;
                Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
                break;
        }
    }
}
