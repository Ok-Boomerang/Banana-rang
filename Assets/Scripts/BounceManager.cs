using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceManager : MonoBehaviour
{
    public static int bounceLeft;
    public static GameObject x;

    void Start()
    {
        bounceLeft = Winning.startBounce;
        x = GameObject.Find("X").gameObject;
        x.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = bounceLeft.ToString();
        if (bounceLeft == 0) x.SetActive(true);

    }
}
