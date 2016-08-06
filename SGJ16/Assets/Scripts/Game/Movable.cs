using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class Movable : MonoBehaviour
    {
       // public Material movableMaterial = new Material("..\\Materials\\ghost\ skin.mat");

        Quaternion firstRotation = Quaternion.Euler(0, 0, 0);
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 eulerRotation;

        int lastExecutedMove;
        List<Vector3> positionsThroughTime;

        int speed = 7;
        int rotationSpeed = 300;
        public int movementPoints;

        public bool isMoving = false;
        public bool canMove = true;

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
            gameObject.transform.rotation = firstRotation;
            rotation = gameObject.transform.rotation;

            ActivateField();
        }

        void Update()
        {
            if (rotation != gameObject.transform.rotation)
            {
                //print(rotation.eulerAngles.z);
                if(Mathf.Abs(rotation.eulerAngles.z - gameObject.transform.rotation.eulerAngles.z) < 5)
                {
                    gameObject.transform.rotation = rotation;
                    eulerRotation = new Vector3(0,0, rotation.eulerAngles.z);
                }
                else
                {
                    //print(transform.rotation.eulerAngles.z);
                    float step = rotationSpeed * Time.deltaTime;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step);
                }

            }
            if (position != gameObject.transform.position)
            {
                if (Mathf.Abs(position.x - transform.position.x) + Mathf.Abs(position.y - transform.position.y) < 0.1f)
                {
                    isMoving = false;
                    gameObject.transform.position = position;

                    ActivateField();

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
            gameObject.transform.rotation = firstRotation;
            rotation = gameObject.transform.rotation;
            canMove = true;

            ActivateField();
        }

        public Vector3 GetFirstPosition()
        {
            return positionsThroughTime[0];
        }

        public void MakeAMove()
        {
            if (!canMove)
                return;

            else if (gameObject.tag == "Enemy")
                gameObject.GetComponent<Enemy>().UpdatePosition();
            else if(IsExecutingPastMovements())
            {
                if(movementPoints != 0)
                    position = positionsThroughTime[++lastExecutedMove];
                
                //gameObject.transform.position = position;
                //Debug.Log(position + " " + transform.position);
            }
            else
            {
                /*if (gameObject.tag == "Enemy")
                {
                    gameObject.GetComponent<Enemy>().UpdatePosition();
                }*/
            }

           // Quaternion.RotateTowards()
            Vector3 lastDirection = position - gameObject.transform.position;
            
            if (lastDirection.x == 1)
            {
                rotation = Quaternion.Euler(0, 0, 90);
            }
            if (lastDirection.x == -1)
            {
                rotation = Quaternion.Euler(0, 0, 270);
            }
        
            if (lastDirection.y == 1)
            {
                rotation = Quaternion.Euler(0, 0, 180);
            }
            if (lastDirection.y == -1)
            {
                rotation = Quaternion.Euler(0, 0, 0);
            }

            movementPoints = 1;
        }

        public bool IsExecutingPastMovements()
        {
            return lastExecutedMove < positionsThroughTime.Count - 1;
        }

        public GameObject GetFieldUnderMovable()
        {
            return Grid.fields[(int)position.y][(int)position.x];
        }

        void ActivateField()
        {
            Field field = GetFieldUnderMovable().GetComponent<Field>();
            if(field != null)
                field.DoAction(this);
        }

        public void ClearPositions()
        {
            positionsThroughTime.Clear();
            positionsThroughTime.Add(transform.position);
        }
    }
}
