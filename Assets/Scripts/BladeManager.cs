using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladeManager : MonoBehaviour
{
    public static int bladeLeft;
    public static GameObject bladex;

    void Start()
    {
        bladeLeft = Winning.startBlade;
        bladex = GameObject.Find("BladeX").gameObject;
        bladex.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = bladeLeft.ToString();
        if (bladeLeft == 0) bladex.SetActive(true);

    }
}
