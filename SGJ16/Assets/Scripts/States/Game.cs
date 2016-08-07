using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Game;
using UnityEngine.SceneManagement;
using Assets.Scripts.Effects;

namespace Assets.Scripts.States
{
    class Game : State
    {

        public double BUTTONWIDTH;
        public double BUTTONHEIGHT;
        public double FIRSTLABELPOSX;
        public double FIRSTLABELPOSY;
        public double FONTSIZE;

        public override void Init()
        {
            Grid.isTimeFlowing = true;
            FIRSTLABELPOSX = 0.05 * Screen.width;
            FIRSTLABELPOSY = 0.05 * Screen.height;
            FONTSIZE = 0.1 * Screen.height;

        }

        public override void UpdateLoop()
        {
            FIRSTLABELPOSX = 0.05 * Screen.width;
            FIRSTLABELPOSY = 0.05 * Screen.height;
            FONTSIZE = 0.06 * Screen.height;

            if (!Grid.isAnyEnemyAlive)
            {
                Debug.Log("Level won");
                TextRendering.PrintMessage("Level won!\n Press spacebar to continue.");
                //ChangeState<CleanUp>();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ++LevelManager.currentLevel;
                    SceneManager.LoadScene(1);
                }
            }
            else if (Grid.lifes < 0)
            {
                Debug.Log("Level lost");

                ChangeState<CleanUp>();

            }

            if (Input.GetKeyDown(KeyCode.Escape) && Grid.isTimeFlowing)
            {
                ChangeState<Pause>();

            }
        }

        public void OnGUI()
        {
            GUIStyle style = new GUIStyle();// = GUIStyle.none;
            style.fontSize = (int)(FONTSIZE);
            style.font = GetComponent<FontsGetter>().font;



            GUI.Label(new Rect((float)FIRSTLABELPOSX, (float)FIRSTLABELPOSY, 100, 20), "Level: " + (LevelManager.currentLevel + 1), style);

            GUI.Label(new Rect((float)FIRSTLABELPOSX, 1.2f*(float)FIRSTLABELPOSY + (float)FONTSIZE, 100, 20), "Lifes: " + (Grid.lifes + 1), style);
        }
    }

}