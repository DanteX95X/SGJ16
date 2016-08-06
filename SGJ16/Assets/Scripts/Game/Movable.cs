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
    //    public Quaternion rotation;

        int lastExecutedMove;
        List<Vector3> positionsThroughTime;

        int speed = 3;
        public int movementPoints;

        public bool isMoving = false;

        public int MovementPoints
        {
            get { return movementPoints; }
            set { movementPoints = value; }
        }

        void Start()
        {
            positionsThroughTime = new List<Vector3>();
            position = gameObject.transform.position;
            positionsThroughTime.Add(position);
            lastExecutedMove = 0;
            movementPoints = 1;
        }

        void Update()
        {
            if (position != gameObject.transform.position)
            {
                if (Mathf.Abs(position.x - transform.position.x) + Mathf.Abs(position.y - transform.position.y) < 0.1f)
                {
                    isMoving = false;
                    gameObject.transform.position = position;

                    if (!IsExecutingPastMovements())
                    {
                        ++lastExecutedMove;
                        positionsThroughTime.Add(position);
                    }
                }
                else
                {
                    isMoving = true;
                    transform.position += (position - transform.position) * Time.deltaTime * speed;
                }
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
                position = positionsThroughTime[++lastExecutedMove];
                
                //gameObject.transform.position = position;
                Debug.Log(position + " " + transform.position);
            }
            else
            {
                if (gameObject.tag == "Enemy")
                {
                    gameObject.GetComponent<Enemy>().UpdatePosition();
                }
            }

            Vector3 lastDirection = position - gameObject.transform.position;
            
            if (lastDirection.x == 1)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (lastDirection.x == -1)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
            }
        
            if (lastDirection.y == 1)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            if (lastDirection.y == -1)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

        }

        public bool IsExecutingPastMovements()
        {
            return lastExecutedMove < positionsThroughTime.Count - 1;
        }

        public GameObject GetFieldUnderMovable()
        {
            return Grid.fields[(int)position.y][(int)position.x];
        }
    }
}
