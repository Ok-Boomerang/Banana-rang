using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coolboom : MonoBehaviour
{
    private static GameObject boomer;
    public static float _maxdistance = 22f;
    private static Vector3 centeroftravel;
    private static float alpha1 = 0f;
    private static float x;
    private static float y;
    private static float startalpha;
    private static float tilt1; 

    public static float middledist = 0f;
    // Start is called before the first frame update
    void Start()
    {
        boomer = GameObject.Find("Boomerang");
    }
    
    public static void throwboomerang(float angle, float power)
    {
        middledist =
            (power * _maxdistance > _maxdistance ? _maxdistance : power * _maxdistance);
        var angle2 = angle * Mathf.Deg2Rad;
        x = middledist * Mathf.Cos(angle2);
        y = middledist * Mathf.Sin(angle2);
        centeroftravel = new Vector3(boomer.transform.position.x + x, boomer.transform.position .y + y, boomer.transform.position .z);
        alpha1 = (180f+ angle) *  Mathf.Deg2Rad;
        startalpha = (180f + angle) *  Mathf.Deg2Rad;
        tilt1 = angle2; 
    }

    public static void moveupdate()
    {
        if (alpha1 >= startalpha + (2 * Mathf.PI))
        {
            Boomerang.resetboom();
            return;
        }
        boomer.transform.position = new Vector2(
                centeroftravel.x + (x * MCos(alpha1) * MCos(tilt1)) - (3f * MSin(alpha1) * MSin(tilt1)),
                centeroftravel.y + (x * MCos(alpha1) * MSin(tilt1)) + (3f * MSin(alpha1) * MCos(tilt1)));

        alpha1 += 0.04f;
    }

    static float MCos(float value)
    {
        return Mathf.Cos(value);
    }

    static float MSin(float value)
    {
        return Mathf.Sin(value);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject GO = other.gameObject;
        switch (GO.tag) 
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
                boomer.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
                Boomerang._thrown = false;
                Boomerang.globalArrow.localScale = new Vector3(0f, 0f, 0f);
                break;
        }
    }

}
