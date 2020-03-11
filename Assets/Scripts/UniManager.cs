using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniManager : MonoBehaviour
{
    public static int uniLeft;
    public static GameObject x;

    void Start()
    {
        uniLeft = Winning.startUni;
        x = GameObject.Find("X").gameObject;
        x.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = uniLeft.ToString();
        if (uniLeft == 0) x.SetActive(true);

    }
}
