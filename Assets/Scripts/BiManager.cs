using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiManager : MonoBehaviour
{
    public static int biLeft;
    public static GameObject x;

    void Start()
    {
        biLeft = Winning.startBi;
        x = GameObject.Find("X").gameObject;
        x.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = biLeft.ToString();
        if(biLeft == 0) x.SetActive(true);
    }

}
