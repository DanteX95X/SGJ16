using UnityEngine;
using System.Collections;

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
                float dX = gameObject.transform.position.x - targetPosition.x;
                float dY = gameObject.transform.position.y - targetPosition.y;

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