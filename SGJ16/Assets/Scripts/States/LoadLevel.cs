using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.States
{
    class LoadLevel : State
    {
        int mapWidth;
        int mapHeight;

        [SerializeField]
        GameObject field;
        

        public override void Init()
        {
            mapWidth = 6;
            mapHeight = 6;

            GameObject grid = new GameObject("grid");

            for(int i = 0; i < mapWidth; ++i)
            {
                for(int j = 0; j < mapHeight; ++j)
                {
                    GameObject currentField = Instantiate(field, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                    currentField.transform.parent = grid.transform;
                }
            }

            ChangeState<DummyState>();
        }

        public override void UpdateLoop()
        {
            
        }

    }
}
