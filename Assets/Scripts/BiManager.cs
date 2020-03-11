using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiManager : MonoBehaviour
{
    public static int biLeft;
    public static GameObject bix;

    void Start()
    {
        biLeft = Winning.startBi;
        bix = GameObject.Find("BiX").gameObject;
        bix.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = biLeft.ToString();
        if(biLeft == 0) bix.SetActive(true);
    }

}
