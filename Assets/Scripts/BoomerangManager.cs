using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomerangManager : MonoBehaviour
{
    public static int boomerangsLeft = 5;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "x" + boomerangsLeft;

    }
}
