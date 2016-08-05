using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class Movable : MonoBehaviour
    {
        public Vector3 position;
        int lastExecutedMove;
        List<Vector3> positionsThroughTime;

        void Start()
        {
            positionsThroughTime = new List<Vector3>();
            position = gameObject.transform.position;
            positionsThroughTime.Add(position);
            lastExecutedMove = 0;
        }

        void Update()
        {
            if (position != gameObject.transform.position)
            {
                gameObject.transform.position = position;
                ++lastExecutedMove;

                if (!IsExecutingPastMovements())
                    positionsThroughTime.Add(position);       
            }
        }

        public void ResetPosition()
        {
            position = GetFirstPosition();
            gameObject.transform.position = position;
            lastExecutedMove = 0;
        }

        public Vector3 GetFirstPosition()
        {
            return positionsThroughTime[0];
        }

        public void MakeAMove()
        {
            if(IsExecutingPastMovements())
            {
                gameObject.transform.position = positionsThroughTime[++lastExecutedMove];
                position = gameObject.transform.position;
            }
        }

        public bool IsExecutingPastMovements()
        {
            return lastExecutedMove < positionsThroughTime.Count - 1;
        }
    }
}
