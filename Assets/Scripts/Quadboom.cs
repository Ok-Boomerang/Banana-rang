using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadboom : MonoBehaviour
{
    private static GameObject boomer;
    public static float _maxdistance = 40f;
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
}
