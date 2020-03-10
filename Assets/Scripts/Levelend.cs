using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levelend : MonoBehaviour
{
    public static Text gameOverText;
    public static GameObject next;
    public static GameObject replay;
    void Awake()
    {
        gameOverText = transform.GetChild(0).GetComponent<Text>();
        replay = transform.Find("Replay").gameObject;
        Button replaybtn = replay.GetComponent<Button>();
        replaybtn.onClick.AddListener(Replay);
        next = transform.Find("Next").gameObject;
        Button nextbtn = next.GetComponent<Button>();
        nextbtn.onClick.AddListener(Next);
    }

    private void Update()
    {
        if(gameOverText.text == "Good Try")
        {
            next.SetActive(false);

        }
        else
        {
            next.SetActive(true);
        }
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
