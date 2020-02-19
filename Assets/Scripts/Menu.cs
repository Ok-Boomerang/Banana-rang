using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image fade;
    // Start is called before the first frame update
     private void Awake () {
            var buttons = transform.Find("Buttons");
    
            var startbtn = buttons.Find("Start").GetComponent<Button>();
            startbtn.onClick.AddListener(StartGame);
    
            var levelsbtn = buttons.Find("Levels").GetComponent<Button>();
            levelsbtn.onClick.AddListener(ShowLevels);
            
            var instructionsbtn = buttons.Find("Instructions").GetComponent<Button>();
            instructionsbtn.onClick.AddListener(ShowInstructions);
    
            var quitbtn = buttons.Find("Quit").GetComponent<Button>();
            quitbtn.onClick.AddListener(QuitGame);
        }
     private void StartGame () {
         SceneManager.LoadScene(3);
     }
     

     private void QuitGame () {
#if UNITY_EDITOR
         EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
     }

     private void ShowLevels () {
         SceneManager.LoadScene(1);
     }
     private void ShowInstructions () {
         SceneManager.LoadScene(2);
     }
}
