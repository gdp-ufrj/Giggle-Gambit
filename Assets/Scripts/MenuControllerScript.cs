using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControllerScript : MonoBehaviour
{
    public GameObject menuBG, button1, button2, button3, button4;
    private bool creditsOn = false;

    public Sprite menubgimg, creditsimg;

    private void Awake()
    {
        Screen.SetResolution(1920,1080,true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown&&creditsOn)
        {
            returnButtonFunction();
        }
    }

    public void StartButtonFunction()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitButtonFunction()
    {
        Application.Quit();
    }

    public void creditsButtonFunction()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(true);
        menuBG.GetComponent<Image>().sprite = creditsimg;
        creditsOn = true;
    }

    public void returnButtonFunction()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(false);
        menuBG.GetComponent<Image>().sprite = menubgimg;
        creditsOn = false;
    }
    
}
