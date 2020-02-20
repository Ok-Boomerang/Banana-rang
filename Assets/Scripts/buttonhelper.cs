using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buttonhelper : Selectable
{
    public GameObject visual;

    void Update()
    {
        visual.GetComponent<SpriteRenderer>().enabled = IsHighlighted() == true;
        if (!IsPressed()) return;
        switch (gameObject.name)
        {
            case "Start":
                Menu.LoadLevel(3);
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
            default:
                var x = Int32.Parse(gameObject.name) + 2;
                Menu.LoadLevel(x);
                break;
        }
    }
    
    
    
}
