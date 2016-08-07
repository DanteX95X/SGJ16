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
        public override void Init()
        {
            Grid.isTimeFlowing = true;
        }

        public override void UpdateLoop()
        {
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
    }

}