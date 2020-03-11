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
    public static float replayloc;
    public static float replaylocmoved;
    void Awake()
    {
        gameOverText = transform.GetChild(0).GetComponent<Text>();
        replay = transform.Find("Replay").gameObject;
        Button replaybtn = replay.GetComponent<Button>();
        replaybtn.onClick.AddListener(Replay);
        next = transform.Find("Next").gameObject;
        Button nextbtn = next.GetComponent<Button>();
        nextbtn.onClick.AddListener(Next);
        replayloc = replay.transform.position.x;
        replaylocmoved = replayloc + 110f;
    }

    private void Update()
    {
        if(gameOverText.text == "Good Try")
        {
            next.SetActive(false);
            replay.transform.position = new Vector3(replaylocmoved, replay.transform.position.y, replay.transform.position.z);
            replay.SetActive(true);
        }
        else if (gameOverText.text == "That's all!")
        {
            next.SetActive(false);
            replay.SetActive(false);
        }
        else
        {
            next.SetActive(true);
            replay.transform.position = new Vector3(replayloc, replay.transform.position.y, replay.transform.position.z);
            replay.SetActive(true);
        }
    }

    private void Replay()
    {
        Boomerang.Restart();
        Menu.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    private void Next()
    {
        Boomerang.Next();
        Menu.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
