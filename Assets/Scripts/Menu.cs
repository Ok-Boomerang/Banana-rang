using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Texture2D cursor;
    // Start is called before the first frame update
     private void Awake () {
            var xspot = cursor.width / 2;
            var yspot = cursor.height / 2;
            Vector2 hotSpot = new Vector2(xspot,yspot);
            Cursor.SetCursor(cursor, hotSpot, CursorMode.Auto);
     }
     public static void QuitGame () {
#if UNITY_EDITOR
         EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
     }
     public static void LoadLevel(int levelnum)
     {
         SceneManager.LoadScene(levelnum);
     }
}
