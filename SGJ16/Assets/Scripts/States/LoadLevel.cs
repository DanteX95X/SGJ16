using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Game;

namespace Assets.Scripts.States
{
    class LoadLevel : State
    {
        int mapWidth;
        int mapHeight;

        [SerializeField]
        GameObject field = null;

        [SerializeField]
        GameObject player = null;
        

        public override void Init()
        {
            mapWidth = 6;
            mapHeight = 6;

            GameObject grid = new GameObject("grid");

            GameObject newPlayer = Instantiate(player, new Vector3(0, 0, -1), Quaternion.identity) as GameObject;
            newPlayer.AddComponent<Player>();
            newPlayer.AddComponent<Movable>();

            for(int i = 0; i < mapWidth; ++i)
            {
                for(int j = 0; j < mapHeight; ++j)
                {
                    GameObject newField = Instantiate(field, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                    newField.transform.parent = grid.transform;
                }
            }

            ChangeState<DummyState>();
        }

        public override void UpdateLoop()
        {
            
        }

    }
}
