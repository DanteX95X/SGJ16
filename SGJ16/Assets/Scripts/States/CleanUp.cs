using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Game;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.States
{
    class CleanUp : State
    {
        public override void Init()
        {
            Grid.fields = null;
            ChangeState<DummyState>();
            SceneManager.LoadScene(0);
        }

        public override void UpdateLoop()
        {
            
        }
    }
}
