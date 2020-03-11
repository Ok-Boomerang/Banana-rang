using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadManager : MonoBehaviour
{
    public static int quadLeft;
    public static GameObject quadx;

    void Start()
    {
        quadLeft = Winning.startQuad;
        quadx = GameObject.Find("QuadX").gameObject;
        quadx.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = quadLeft.ToString();
        if (quadLeft == 0) quadx.SetActive(true);
    }
}
