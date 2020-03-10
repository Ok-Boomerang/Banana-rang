using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonhelper : Selectable
{
    public GameObject visual;

    void Update()
    {
        visual.GetComponent<RawImage>().enabled = IsHighlighted() == true;
        if (!IsPressed()) return;
        int x;
        switch (gameObject.name)
        {
            case "Start":
                Menu.LoadLevel(2);
                break;
            case "Levels":
                Menu.LoadLevel(1);
                break;
            case "Instructions":
                Menu.LoadLevel(2);
                break;
            case "Quit":
                Menu.QuitGame();
                break;
            case "Menu":
                Menu.LoadLevel(0);
                break;
            case "Back":
                Menu.LoadLevel(0);
                break;
            case "Restart":
                Boomerang.Restart();
                Menu.LoadLevel(SceneManager.GetActiveScene().buildIndex);
                break;
            default:
                x = Int32.Parse(gameObject.name) + 1;
                Menu.LoadLevel(x);
                break;
        }
    }
    
    
    
}
