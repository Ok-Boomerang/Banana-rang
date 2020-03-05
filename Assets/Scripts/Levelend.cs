using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levelend : MonoBehaviour
{
    public static Text gameOverText;
    void Awake()
    {
        gameOverText = transform.GetChild(0).GetComponent<Text>();
        if (gameOverText.text == "Good Try")
        {
            gameOverText.color = Color.red;
        }
        var buttons = transform.Find("Buttons");
        Button replaybtn = buttons.Find("Replay").GetComponent<Button>();
        replaybtn.onClick.AddListener(Replay);
        Button nextbtn = buttons.Find("Next").GetComponent<Button>();
        nextbtn.onClick.AddListener(Next);
    }

    private void Replay()
    {
        Boomerang.Restart();
        Menu.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    private void Next()
    {
        Boomerang.Restart();
        Menu.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
