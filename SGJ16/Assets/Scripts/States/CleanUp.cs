using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Game;
using UnityEngine.SceneManagement;
using UnityEngine;
using Assets.Scripts.Effects;

namespace Assets.Scripts.States
{
    class CleanUp : State
    {
        public override void Init()
        {
            Grid.isTimeFlowing = false;
        }

        public override void UpdateLoop()
        {
            TextRendering.PrintMessage("Level lost!\nPress Y to restart level.\nPress N to return to main menu.");
            if (Input.GetKeyDown(KeyCode.N))
            {
                Grid.fields = null;
                MonoBehaviour[] allObjects = FindObjectsOfType<MonoBehaviour>();
                foreach (MonoBehaviour obj in allObjects)
                    Destroy(obj);
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Y))
                SceneManager.LoadScene(1);
        }
    }
}
