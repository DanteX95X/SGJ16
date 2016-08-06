﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour {


    public float BUTTONWIDTH;
    public float BUTTONHEIGHT;
    public float FIRSTBUTTONPOSX;
    public float FIRSTBUTTONPOSY;

    // Use this for initialization
    void Start ()
    {
        CheckResolution();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckResolution();
	}   

    void CheckResolution()
    {
    BUTTONWIDTH = Screen.width / 2;
    BUTTONHEIGHT = Screen.height / 5;
    FIRSTBUTTONPOSX = Screen.width / 2 - Screen.width/4; //this is a BUTTONWITH
    FIRSTBUTTONPOSY = Screen.height / 10;
}  

    public void OnGUI()
    {
        if(GUI.Button(new Rect(FIRSTBUTTONPOSX, FIRSTBUTTONPOSY, BUTTONWIDTH, BUTTONHEIGHT), "PLAY"))
        {
            SceneManager.LoadScene(1);

        }

        if (GUI.Button(new Rect(FIRSTBUTTONPOSX, 2*FIRSTBUTTONPOSY + BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), "CREDITS"))
        {

        }

        if (GUI.Button(new Rect(FIRSTBUTTONPOSX, 3 * FIRSTBUTTONPOSY + 2*BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), "EXIT"))
        {

        }
    }
}
