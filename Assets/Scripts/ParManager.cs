using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParManager : MonoBehaviour
{
    public static int par;

    void Start()
    {
        par = Winning.globalPar;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = par.ToString();

    }
}
