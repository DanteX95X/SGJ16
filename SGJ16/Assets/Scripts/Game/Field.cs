using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Effects;

namespace Assets.Scripts.Game
{
    class Field : MonoBehaviour
    {
        public enum FieldType
        {
            CLEAR,
            LOST_TURN,
            DOUBLE_MOVEMENT,
            TIME_VORTEX,
        }

        FieldType type;

        [SerializeField]
        GameObject effect = null;

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
                    if (movable.tag != "Enemy")
                    {
                        movable.movementPoints = 0;
                        TextRendering.PrintMessage("Frozen!!!");
                        Instantiate(effect, new Vector3(transform.position.x, transform.position.y, Grid.depth), transform.rotation);
                        GetComponent<AudioSource>().Play();
                    }
                    break;
                case FieldType.DOUBLE_MOVEMENT:
                    movable.movementPoints = 2;
                    break;
                case FieldType.TIME_VORTEX:
                    Movable[] movables = FindObjectsOfType<Movable>();
                    foreach(Movable movableObject in movables)
                    {
                        movableObject.ResetPosition();
                        movableObject.isMoving = false;
                    }
                    Player player = FindObjectOfType<Player>();
                    player.gameObject.GetComponent<Movable>().ClearPositions();
                    TextRendering.PrintMessage("Time travel!!!");
                    Instantiate(effect, new Vector3(transform.position.x, transform.position.y, Grid.depth), transform.rotation);
                    GetComponent<AudioSource>().Play();
                    break;
            }   
        }
    }
}
