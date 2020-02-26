using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladeManager : MonoBehaviour
{
    public static int bladeLeft;

    void Start()
    {
        bladeLeft = Winning.startBlade;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "x" + bladeLeft;

    }
}
