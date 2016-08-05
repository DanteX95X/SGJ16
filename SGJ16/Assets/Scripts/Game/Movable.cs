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

        //public Vector3 Position { get; set; }

        void Start()
        {
            position = gameObject.transform.position;
        }

        void Update()
        {
            if (position != gameObject.transform.position)
                gameObject.transform.position = position;
        }
    }
}
