using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class Field : MonoBehaviour
    {
        public enum FieldType
        {
            CLEAR,
            LOST_TURN,
            DOUBLE_MOVEMENT,
        }

        FieldType type;

        public void SetFieldType(FieldType type)
        {
            this.type = type;
        }

        void Start()
        {

        }

        void Update()
        {

        }

        public void DoAction(Movable movable)
        {
            switch(type)
            {
                case FieldType.LOST_TURN:
                    movable.movementPoints = 0;
                    //Debug.Log(movable.movementPoints);
                    break;
                case FieldType.DOUBLE_MOVEMENT:
                    movable.movementPoints = 2;
                    break;
            }
        }
    }
}
