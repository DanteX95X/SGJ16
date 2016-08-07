using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Game;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.States
{

    public class Pause : State
    {
        public float BUTTONWIDTH;
        public float BUTTONHEIGHT;
        public float FIRSTBUTTONPOSX;
        public float FIRSTBUTTONPOSY;

        public Texture[] textures;

        public override void Init()
        {
            Debug.Log("Pause");
            Grid.isTimeFlowing = false;
            CheckResolution();
            textures = GetComponent<ButtonsTextures>().buttonTextures;
        }

        public override void UpdateLoop()
        {
            CheckResolution();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ChangeState<Game>();
            }
        }


        void CheckResolution()
        {
            BUTTONWIDTH = Screen.width / 2;
            BUTTONHEIGHT = Screen.height / 5;
            FIRSTBUTTONPOSX = Screen.width / 2 - Screen.width / 4; //this is a BUTTONWITH
            FIRSTBUTTONPOSY = Screen.height / 10;
        }

        public void OnGUI()
        {

            GUIStyle style = GUIStyle.none;
            style.alignment = TextAnchor.MiddleCenter;

            if (GUI.Button(new Rect(FIRSTBUTTONPOSX, FIRSTBUTTONPOSY, BUTTONWIDTH, BUTTONHEIGHT), textures[0], style))
            {
                ChangeState<Game>();
            }
            if (GUI.Button(new Rect(FIRSTBUTTONPOSX, 2 * FIRSTBUTTONPOSY + BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), textures[1], style))
            {
                SceneManager.LoadScene(1);
              
            }
            if (GUI.Button(new Rect(FIRSTBUTTONPOSX, 3 * FIRSTBUTTONPOSY + 2 * BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), textures[2], style))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

}