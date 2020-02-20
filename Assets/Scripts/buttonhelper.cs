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
                Menu.StartGame();
                break;
            case "Levels":
                Menu.ShowLevels();
                break;
            case "Instructions":
                Menu.ShowInstructions();
                break;
            case "Quit":
                Menu.QuitGame();
                break;
        }
    }
    
    
    
}
