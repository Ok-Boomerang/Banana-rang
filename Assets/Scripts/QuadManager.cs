using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadManager : MonoBehaviour
{
    public static int quadLeft;

    void Start()
    {
        quadLeft = Winning.startQuad;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = quadLeft.ToString();

    }
}
