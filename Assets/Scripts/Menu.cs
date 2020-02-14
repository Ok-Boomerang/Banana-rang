using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Texture2D cursor;
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
            var xspot = cursor.width / 2;
            var yspot = cursor.height / 2;
            Vector2 hotSpot = new Vector2(xspot,yspot);
            Cursor.SetCursor(cursor, hotSpot, CursorMode.Auto);
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
