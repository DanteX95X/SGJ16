using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        float speed = 10;

        Vector3 velocity = new Vector3(0, 0, 0);

        public void Start()
        {
            transform.position = new Vector3(Grid.width / 2.0f, Grid.height / 2.0f, -6);
        }

        public void Update()
        {

            /*if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                velocity.x += -speed;
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
                velocity.x += speed;

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
                velocity.y += speed;
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
                velocity.y += -speed;

            transform.position += velocity * Time.deltaTime;
            */
            /*if (transform.position.x < 0)
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
                velocity = new Vector3(0, 0, 0);
            }
            else if (transform.position.x > Grid.width)
            { 
                transform.position = new Vector3(Grid.width, transform.position.y, transform.position.z);
                velocity = new Vector3(0, 0, 0);
            }
            if (transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                velocity = new Vector3(0, 0, 0);
            }
            else if (transform.position.y > Grid.height)
            {
                transform.position = new Vector3(transform.position.x, Grid.height, transform.position.z);
                velocity = new Vector3(0, 0, 0);
            }*/

        }
    }
}
