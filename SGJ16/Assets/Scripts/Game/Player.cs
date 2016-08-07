using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.States;
using Assets.Scripts.Effects;

namespace Assets.Scripts.Game
{
    public class Player : MonoBehaviour
    {
        Movable playerMovable;
        bool wasMoved;

        void Start()
        {
            playerMovable = gameObject.GetComponent<Movable>();
            Debug.Log("player spawned");
        }

        void Update()
        {
            if(!playerMovable.isMoving)
                HandleInput();
        }

        void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RewindTime();
                --Grid.lifes;
            }

            if (!Grid.isTimeFlowing)
                return;

            wasMoved = true;
            if (Input.GetKeyDown(KeyCode.W))
                playerMovable.position.y += playerMovable.MovementPoints;
            else if (Input.GetKeyDown(KeyCode.S))
                playerMovable.position.y -= playerMovable.MovementPoints;
            else if (Input.GetKeyDown(KeyCode.A))
                playerMovable.position.x -= playerMovable.MovementPoints;
            else if (Input.GetKeyDown(KeyCode.D))
                playerMovable.position.x += playerMovable.MovementPoints;
            else
                wasMoved = false;

            if(playerMovable.position.x < 0 || playerMovable.position.x >= Grid.width || playerMovable.position.y < 0 || playerMovable.position.y >= Grid.height)
            {
                playerMovable.position = transform.position;
                Debug.Log("Can't move there sucker");
                TextRendering.PrintMessage("Can't move there sucker");
                return;
            }

            if (wasMoved)
            {
                Movable[] movables = FindObjectsOfType<Movable>();
                foreach (Movable movable in movables)
                {
                    //Field movableField = movable.GetFieldUnderMovable().GetComponent<Field>();
                    //movableField.DoAction(movable);
                    movable.MakeAMove();
                    movable.position.x = Mathf.Round(movable.position.x);
                    movable.position.y = Mathf.Round(movable.position.y);
                    movable.transform.position = movable.position;
                }

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                foreach (GameObject enemy in enemies)
                {
                    foreach(GameObject player in players)
                    {
                        if(enemy.GetComponent<Movable>().position == player.GetComponent<Movable>().position)
                        {
                            GetComponent<AudioSource>().Play();
                            //Debug.Log("Time travel!!!");
                            enemy.GetComponent<Movable>().canMove = false;
                        }
                    }
                }

                Grid.isAnyEnemyAlive = false;
                foreach(GameObject enemy in enemies)
                {
                    if (enemy.GetComponent<Movable>().canMove)
                    {
                        Grid.isAnyEnemyAlive = true;
                        break;
                    }
                }

            }
        }

        public void RewindTime()
        {
            Movable[] movables = FindObjectsOfType<Movable>();
            foreach (Movable movable in movables)
            {
                movable.ResetPosition();
            }
            Instantiate(gameObject, playerMovable.GetFirstPosition(), Quaternion.identity);
            Grid.isTimeFlowing = true;
            GetComponent<MaterialChanging>().Changer();
            Destroy(this);
        }

    }
}