using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadManager : MonoBehaviour
{
    public static int quadLeft;
    public static GameObject x;

    void Start()
    {
        quadLeft = Winning.startQuad;
        x = GameObject.Find("X").gameObject;
        x.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = quadLeft.ToString();
        if (quadLeft == 0) x.SetActive(true);
    }
}
