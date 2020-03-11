using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    private GameObject BoomerangsPanel;
    private GameObject ParPanel;
    private GameObject InstPanel;
    private GameObject parPop;
    private GameObject boomPop;
    private GameObject instPop;
    void Start()
    {
        ParPanel = GameObject.Find("ParPanel").gameObject;
        parPop = GameObject.Find("parPop").gameObject;
        Button parbtn = parPop.GetComponent<Button>();
        parbtn.onClick.AddListener(Close);
        if(Boomerang.restarted) ParPanel.SetActive(false);
        BoomerangsPanel = GameObject.Find("BoomerangsPanel").gameObject;
        boomPop = GameObject.Find("boomPop").gameObject;
        Button boombtn = boomPop.GetComponent<Button>();
        boombtn.onClick.AddListener(Close);
        BoomerangsPanel.SetActive(false);
        InstPanel = GameObject.Find("InstPanel").gameObject;
        instPop = GameObject.Find("instPop").gameObject;
        Button instbtn = instPop.GetComponent<Button>();
        instbtn.onClick.AddListener(Close);
        InstPanel.SetActive(false);

    }

    private void Close()
    {
        if(ParPanel.activeSelf == true & BoomerangsPanel.activeSelf == false)
        {
            ParPanel.SetActive(false);
            BoomerangsPanel.SetActive(true);
        }
        else if(ParPanel.activeSelf == false & BoomerangsPanel.activeSelf == true)
        {
            BoomerangsPanel.SetActive(false);
            InstPanel.SetActive(true);
        }
        else if (InstPanel.activeSelf == true)
        {
            InstPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
