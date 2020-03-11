using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolManager : MonoBehaviour
{
    public static int coolLeft;
    public static GameObject x;

    void Start()
    {
        coolLeft = Winning.startCool;
        x = GameObject.Find("X").gameObject;
        x.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = coolLeft.ToString();
        if(coolLeft == 0) x.SetActive(true);
    }

}
