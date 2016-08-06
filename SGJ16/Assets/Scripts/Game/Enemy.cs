using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    public class Enemy : MonoBehaviour
    {
        Movable enemyMovable;

        Vector3 targetPosition = new Vector3(0, 0, 0);

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

        }

        public void UpdatePosition()
        {
            if (enemyMovable.position != targetPosition)
            {

                List<Vector3> neighbours = new List<Vector3>();
                neighbours.Add(transform.position + new Vector3(-enemyMovable.MovementPoints, 0, 0));
                neighbours.Add(transform.position + new Vector3(enemyMovable.MovementPoints, 0, 0));
                neighbours.Add(transform.position + new Vector3(0, -enemyMovable.MovementPoints, 0));
                neighbours.Add(transform.position + new Vector3(0, enemyMovable.MovementPoints, 0));

                MoveTowardsTarget(neighbours);
            }

         }

        void MoveTowardsTarget(List<Vector3> neighbours)
        {
            float currentDistance = Grid.CalculateDistance(transform.position, targetPosition);
            List<Vector3> allowedMovements = new List<Vector3>();
            bool isEndangered = false;
            foreach (Vector3 possiblePosition in neighbours)
            {
                //bool isEndangered = false;
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                foreach (GameObject player in players)
                {
                    if (player.transform.position == possiblePosition)
                        isEndangered = true;
                }

                float consideredDistance = Mathf.Abs(possiblePosition.x - targetPosition.x) + Mathf.Abs(possiblePosition.y - targetPosition.y);
                if (Grid.IsOnGrid(possiblePosition) && consideredDistance < currentDistance && !isEndangered)
                    allowedMovements.Add(possiblePosition);
            }

            if(isEndangered)
            {
                allowedMovements.Clear();
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                foreach (Vector3 possiblePosition in neighbours)
                {
                    if (Grid.IsOnGrid(possiblePosition))
                    {
                        bool isPositionSafe = true;
                        foreach (GameObject player in players)
                        {
                            if (player.transform.position == possiblePosition)
                            {
                                Debug.Log("Not safe " + possiblePosition);
                                isPositionSafe = false;
                            }
                        }

                        if (isPositionSafe)
                            allowedMovements.Add(possiblePosition);
                    }
                }
                Debug.Log(allowedMovements.Count);
            }

            int index = Random.Range(0, allowedMovements.Count);

            if (allowedMovements.Count > 0)
                enemyMovable.position = allowedMovements[index];
        }

        //void MoveAwayFromPlayer()

    }
}