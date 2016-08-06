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
            //float dX = gameObject.transform.position.x - targetPosition.x;
            //float dY = gameObject.transform.position.y - targetPosition.y;
            float currentDistance = Mathf.Abs(transform.position.x - targetPosition.x) + Mathf.Abs(transform.position.y - targetPosition.y);

            List<Vector3> neighbours = new List<Vector3>();
            neighbours.Add(transform.position + new Vector3(-enemyMovable.movementPoints,0,0));
            neighbours.Add(transform.position + new Vector3(enemyMovable.movementPoints, 0, 0));
            neighbours.Add(transform.position + new Vector3(0, -enemyMovable.movementPoints, 0));
            neighbours.Add(transform.position + new Vector3(0, enemyMovable.movementPoints, 0));

            List<Vector3> allowedMovements = new List<Vector3>();
            foreach(Vector3 possiblePosition in neighbours)
            {
                float consideredDistance = Mathf.Abs(possiblePosition.x - targetPosition.x) + Mathf.Abs(possiblePosition.y - targetPosition.y);
                if (IsOnGrid(possiblePosition) && consideredDistance < currentDistance)
                    allowedMovements.Add(possiblePosition);
            }

            int index = Random.Range(0, allowedMovements.Count);

            if(allowedMovements.Count > 0)
                enemyMovable.position = allowedMovements[index];

            /*if ((UnityEngine.Mathf.Abs(dX) > UnityEngine.Mathf.Abs(dY)) && dX != 0)
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
            }*/
         }

        bool IsOnGrid(Vector3 vector)
        {
            return vector.x >= 0 && vector.x < Grid.width && vector.y >= 0 && vector.y < Grid.height;
        }
    }
}