using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniManager : MonoBehaviour
{
    public static int uniLeft;
    public static GameObject unix;

    void Start()
    {
        uniLeft = Winning.startUni;
        unix = GameObject.Find("UniX").gameObject;
        unix.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = uniLeft.ToString();
        if (uniLeft == 0) unix.SetActive(true);

    }
}
