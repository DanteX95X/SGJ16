using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
    public class Player : MonoBehaviour
    {
        //Vector3 position;
        Movable playerMovable;



        void Start()
        {
            //position = gameObject.transform.position;
            playerMovable = gameObject.GetComponent<Movable>();
            Debug.Log("player spawned");
        }

        void Update()
        {
            HandleInput();
        }

        void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
                playerMovable.position.y += 1;
            if (Input.GetKeyDown(KeyCode.S))
                playerMovable.position.y -= 1;
            if (Input.GetKeyDown(KeyCode.A))
                playerMovable.position.x -= 1;
            if (Input.GetKeyDown(KeyCode.D))
                playerMovable.position.x += 1;

            //gameObject.transform.position = position;
        }
    }
}