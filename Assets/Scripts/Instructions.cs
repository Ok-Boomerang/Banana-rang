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
    }
    private void StartGame()
    {
        Boomerang.Restart();
        SceneManager.LoadScene(3);
    }
}
