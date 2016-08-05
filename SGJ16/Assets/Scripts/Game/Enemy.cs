using UnityEngine;
using System.Collections;
//using UnityEngine.Ma

namespace Assets.Scripts.Game
{
    public class Enemy : MonoBehaviour
    {

        Movable enemyMovable;

        Vector3 targetPosition = new Vector3(0, 0, 0);//(5, 0, -1);

        public Vector3 TargetPosition
        {
            get { return targetPosition; }
            set { targetPosition = value; }
        }

        // Use this for initialization
        void Start()
        {
            enemyMovable = gameObject.GetComponent<Movable>();
            Debug.Log("enemy spawned");
        }

        // Update is called once per frame
        void Update()
        {
            if(!enemyMovable.IsExecutingPastMovements())
            {
                UpdatePosition();
            }
        }

        void UpdatePosition()
        {
                float dX = gameObject.transform.position.x - targetPosition.x;
                float dY = gameObject.transform.position.y - targetPosition.y;

                if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) && (gameObject.transform.position != targetPosition))
                {
                    if ((UnityEngine.Mathf.Abs(dX) > UnityEngine.Mathf.Abs(dY)) && dX != 0)
                    {
                        if (dX > 0)
                        {
                            enemyMovable.position.x -= 1;
                        }
                        else
                        {
                            enemyMovable.position.x += 1;
                        }
                    }
                    else if (dY != 0)
                    {
                        if (dY > 0)
                        {
                            enemyMovable.position.y -= 1;
                        }
                        else
                        {
                            enemyMovable.position.y += 1;
                        }
                    }

                }
         }
        

    }

}