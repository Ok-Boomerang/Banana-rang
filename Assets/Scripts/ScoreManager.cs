﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int Score = 0;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Score: " + Score;

    }
}
