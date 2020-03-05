using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiManager : MonoBehaviour
{
    public static int biLeft;

    void Start()
    {
        biLeft = Winning.startBi;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = biLeft.ToString();

    }
}
