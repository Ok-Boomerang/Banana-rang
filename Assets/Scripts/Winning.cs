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
    public GameObject gameOverPanel;
    public string overText = "Good Try";
    public int numofbooms;
    public static int _startBooms;
    public static int globalPar;
    public Transform canvas;
    public Button restartbtn;
    // Start is called before the first frame update
    void Awake()
    {
        _startBooms = numofbooms;
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
        if ((BoomerangManager.boomerangsLeft <= 0 & !Boomerang._thrown)| ScoreManager.Score == _maxScore)
        {
            if (ScoreManager.Score == _maxScore)
            {
                var numBooms = BoomerangManager.boomerangsLeft;
                if (numBooms <= _startBooms - globalPar - 2) { overText = "Double Bogey"; }
                else if (numBooms == _startBooms - globalPar - 1) { overText = "Bogey"; }
                else if (numBooms == _startBooms - globalPar) { overText = "On Par!"; }
                else if (numBooms == _startBooms - globalPar + 1) { overText = "Birdie"; }
                else if (numBooms >= _startBooms - globalPar + 2) { overText = "Eagle"; }
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
