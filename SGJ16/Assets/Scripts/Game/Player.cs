﻿using UnityEngine;
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
            HandleInput();
        }

        void HandleInput()
        {
            wasMoved = true;
            if (Input.GetKeyDown(KeyCode.W))
                playerMovable.position.y += 1;
            else if (Input.GetKeyDown(KeyCode.S))
                playerMovable.position.y -= 1;
            else if (Input.GetKeyDown(KeyCode.A))
                playerMovable.position.x -= 1;
            else if (Input.GetKeyDown(KeyCode.D))
                playerMovable.position.x += 1;
            else
                wasMoved = false;

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
                            Debug.Log("Colision");
                        }
                    }
                }
            }
        }
    }
}