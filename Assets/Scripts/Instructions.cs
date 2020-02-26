using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        var buttons = transform.Find("Buttons");

        var startbtn = transform.Find("Start").GetComponent<Button>();
        startbtn.onClick.AddListener(StartGame);
        var menubtn = transform.Find("menu").GetComponent<Button>();
        menubtn.onClick.AddListener(toMenu);
    }
    private void StartGame()
    {
        Boomerang.Restart();
        SceneManager.LoadScene(3);
    }

    void toMenu()
    {
        Menu.LoadLevel(0);
    }
}
