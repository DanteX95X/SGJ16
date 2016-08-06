using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
            wasMoved = true;
            if (Input.GetKeyDown(KeyCode.W))
                playerMovable.position.y += playerMovable.movementPoints;
            else if (Input.GetKeyDown(KeyCode.S))
                playerMovable.position.y -= playerMovable.movementPoints;
            else if (Input.GetKeyDown(KeyCode.A))
                playerMovable.position.x -= playerMovable.movementPoints;
            else if (Input.GetKeyDown(KeyCode.D))
                playerMovable.position.x += playerMovable.movementPoints;
            else
                wasMoved = false;

            if(playerMovable.position.x < 0 || playerMovable.position.x >= Grid.width || playerMovable.position.y < 0 || playerMovable.position.y >= Grid.height)
            {
                playerMovable.position = transform.position;
                Debug.Log("Can't move there sucker");
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Movable[] movables = FindObjectsOfType<Movable>();
                foreach (Movable movable in movables)
                {
                    movable.ResetPosition();
                }
                Instantiate(gameObject, playerMovable.GetFirstPosition(), Quaternion.identity);
                Destroy(this);
            }

            if (wasMoved)
            {
                Movable[] movables = FindObjectsOfType<Movable>();
                foreach (Movable movable in movables)
                {
                    movable.MakeAMove();
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
                        }
                    }
                }
            }
        }
    }
}