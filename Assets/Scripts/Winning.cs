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
    public int _par;
    public int uniBooms;
    public int biBooms;
    public int bladeBooms;
    public int bounceBooms;
    public int quadBooms;
    public int coolBooms;
    public GameObject gameOverPanel;
    public string overText = "Good Try";
    public static int _startBooms;
    public static int boomerangsLeft;
    public static int globalPar;
    public static int startUni;
    public static int startBi;
    public static int startBlade;
    public static int startBounce;
    public static int startQuad;
    public Transform canvas;
    // Start is called before the first frame update
    void Awake()
    {
        startUni = uniBooms;
        startBi = biBooms;
        startBlade = bladeBooms;
        startBounce = bounceBooms;
        startQuad = quadBooms;
        _startBooms = uniBooms + biBooms + bladeBooms + bounceBooms + quadBooms;
        boomerangsLeft = _startBooms;
        globalPar = _par;
    }
    void Start()
    { 
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
        if ((boomerangsLeft <= 0 & !Boomerang._thrown)| ScoreManager.Score == _maxScore)
        {
            if (ScoreManager.Score == _maxScore)
            {
                if (boomerangsLeft <= _startBooms - globalPar - 2) { overText = "Double Bogey"; }
                else if (boomerangsLeft == _startBooms - globalPar - 1) { overText = "Bogey"; }
                else if (boomerangsLeft == _startBooms - globalPar) { overText = "On Par!"; }
                else if (boomerangsLeft == _startBooms - globalPar + 1) { overText = "Birdie"; }
                else if (boomerangsLeft == _startBooms - globalPar + 2) { overText = "Eagle"; }
                else if (boomerangsLeft >= _startBooms - globalPar + 3) { overText = "Albatross"; }
            }
            else
            {
                overText = "Good Try";
                Levelend.gameOverText.color = new Color32(233, 14, 14, 255);
            }
            GameOver();
        }
    }

    void Restart()
    {
        Boomerang.Restart();
        Menu.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    void toMenu()
    {
        Menu.LoadLevel(0);
    }
}
