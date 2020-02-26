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
    public Button restartbtn;
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
        restartbtn = canvas.Find("reset").GetComponent<Button>();
    }
    void Start()
    { 
        gameOverPanel.SetActive(false);
        restartbtn.gameObject.SetActive(true); 
        restartbtn.onClick.AddListener(Restart);
    }
    void GameOver()
    {
        gameOverPanel.SetActive(true);
        restartbtn.gameObject.SetActive(false);
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
                else if (boomerangsLeft >= _startBooms - globalPar + 2) { overText = "Eagle"; }
            }
            else
            {
                overText = "Good Try";
            }
            GameOver();
        }
    }

    void Restart()
    {
        Boomerang.Restart();
        Menu.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
