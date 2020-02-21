using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    public int _maxScore = 8;
    public int _par = 3;
    public static int _startBooms;
    public GameObject gameOverPanel;
    public string overText = "Good Try";
    public int numofbooms = 5;
    // Start is called before the first frame update
    void Start()
    {
        _startBooms = numofbooms;
        gameOverPanel.SetActive(false);
    }
    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Levelend.gameOverText.text = overText;
        Boomerang.GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        if ((BoomerangManager.boomerangsLeft <= 0 & !Boomerang._thrown)| ScoreManager.Score == _maxScore)
        {
            if (ScoreManager.Score == _maxScore)
            {
                var numBooms = BoomerangManager.boomerangsLeft;
                switch (numBooms)
                {
                    case 2:
                        overText = "On Par!";
                        break;
                    case 1:
                        overText = "Bogey";
                        break;
                    case 0:
                        overText = "Double Bogey";
                        break;
                    case 3:
                        overText = "Birdie";
                        break;
                    case 4:
                        overText = "Eagle";
                        break;

                }
            }
            else
            {
                overText = "Good Try";
            }
            GameOver();
        }
    }
}
