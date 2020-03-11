using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceManager : MonoBehaviour
{
    public static int bounceLeft;
    public static GameObject bouncex;

    void Start()
    {
        bounceLeft = Winning.startBounce;
        bouncex = GameObject.Find("BounceX").gameObject;
        bouncex.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = bounceLeft.ToString();
        if (bounceLeft == 0) bouncex.SetActive(true);

    }
}
