using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceManager : MonoBehaviour
{
    public static int bounceLeft;

    void Start()
    {
        bounceLeft = Winning.startBounce;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = bounceLeft.ToString();

    }
}
