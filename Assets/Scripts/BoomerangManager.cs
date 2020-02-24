using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomerangManager : MonoBehaviour
{
    public static int boomerangsLeft;

    void Start()
    {
        boomerangsLeft = Winning._startBooms;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "x" + boomerangsLeft;

    }
}
