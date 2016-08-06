using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Game;
using UnityEngine.SceneManagement;

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
                ChangeState<CleanUp>();
            }
            else if(Grid.lifes < 0)
            {
                Debug.Log("Level lost");
                ChangeState<CleanUp>();
            }
        }
    }
}
