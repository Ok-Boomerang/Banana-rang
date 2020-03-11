using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladeManager : MonoBehaviour
{
    public static int bladeLeft;
    public static GameObject x;

    void Start()
    {
        bladeLeft = Winning.startBlade;
        x = GameObject.Find("X").gameObject;
        x.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = bladeLeft.ToString();
        if (bladeLeft == 0) x.SetActive(true);

    }
}
