using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniManager : MonoBehaviour
{
    public static int uniLeft;

    void Start()
    {
        uniLeft = Winning.startUni;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = uniLeft.ToString();

    }
}
