using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class Grid
    {
        public static int width = 0;
        public static int height = 0;
        public static List<List<GameObject>> fields = new List<List<GameObject>>();

        public static bool IsOnGrid(Vector3 vector)
        {
            return vector.x >= 0 && vector.x < Grid.width && vector.y >= 0 && vector.y < Grid.height;
        }

        public static float CalculateDistance(Vector3 first, Vector3 second)
        {
            return Mathf.Abs(first.x - second.x) + Mathf.Abs(first.y - second.y);
        }
    }
}
