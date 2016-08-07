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

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.position += new Vector3(-speed, 0) * Time.deltaTime;
            if (Input.GetKey(KeyCode.RightArrow))
                transform.position += new Vector3(speed, 0) * Time.deltaTime;
            if (Input.GetKey(KeyCode.DownArrow))
                transform.position += new Vector3(0, -speed) * Time.deltaTime;
            if (Input.GetKey(KeyCode.UpArrow))
                transform.position += new Vector3(0, speed) * Time.deltaTime;
            if (Input.GetKey(KeyCode.KeypadMinus))
                transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
            if (Input.GetKey(KeyCode.KeypadPlus))
                transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

            
            if (transform.position.x < 0)
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
            else if (transform.position.x > Grid.width)
                transform.position = new Vector3(Grid.width, transform.position.y, transform.position.z);
            if (transform.position.y < 0)
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            else if (transform.position.y > Grid.height)
                transform.position = new Vector3(transform.position.x, Grid.height, transform.position.z);
            if (transform.position.z > -1)
                transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            else if (transform.position.z < -20)
                transform.position = new Vector3(transform.position.x, transform.position.y, -20);

        }
    }
}
