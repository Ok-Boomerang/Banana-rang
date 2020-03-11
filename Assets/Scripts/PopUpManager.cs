﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    private GameObject BoomerangsPanel;
    private GameObject ParPanel;
    private GameObject InstPanel;
    private GameObject MushPanel;
    private GameObject BiPanel;
    private GameObject parPop;
    private GameObject boomPop;
    private GameObject instPop;
    private GameObject mushPop;
    private GameObject biPop;
    void Start()
    {
        if (GameObject.Find("ParPanel"))
        {
            ParPanel = GameObject.Find("ParPanel").gameObject;
            parPop = GameObject.Find("parPop").gameObject;
            Button parbtn = parPop.GetComponent<Button>();
            parbtn.onClick.AddListener(Close);
            if (Boomerang.restarted) ParPanel.SetActive(false);
        }
        if(GameObject.Find("BoomerangsPanel"))
        {
            BoomerangsPanel = GameObject.Find("BoomerangsPanel").gameObject;
            boomPop = GameObject.Find("boomPop").gameObject;
            Button boombtn = boomPop.GetComponent<Button>();
            boombtn.onClick.AddListener(Close);
            BoomerangsPanel.SetActive(false);
        }
        if (GameObject.Find("InstPanel"))
        {
            InstPanel = GameObject.Find("InstPanel").gameObject;
            instPop = GameObject.Find("instPop").gameObject;
            Button instbtn = instPop.GetComponent<Button>();
            instbtn.onClick.AddListener(Close);
            InstPanel.SetActive(false);
        }
        if(GameObject.Find("MushPanel"))
        {
            MushPanel = GameObject.Find("MushPanel").gameObject;
            mushPop = GameObject.Find("mushPop").gameObject;
            Button mushbtn = mushPop.GetComponent<Button>();
            mushbtn.onClick.AddListener(Close2);
            if (Boomerang.restarted) MushPanel.SetActive(false);
        }
        if(GameObject.Find("BiPanel"))
        {
            BiPanel = GameObject.Find("BiPanel").gameObject;
            biPop = GameObject.Find("biPop").gameObject;
            Button bibtn = biPop.GetComponent<Button>();
            bibtn.onClick.AddListener(Close3);
            if (Boomerang.restarted) MushPanel.SetActive(false);
        }

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

    private void Close2()
    {
        MushPanel.SetActive(false);
    }

    private void Close3()
    {
        BiPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
