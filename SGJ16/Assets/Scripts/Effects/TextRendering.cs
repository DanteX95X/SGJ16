using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Effects
{
    class TextRendering : MonoBehaviour 
    {
        [SerializeField]
        float lifetime = 3.0f;

        [SerializeField]
        float timeCounter = 0;

        TextMesh mesh;
        void Start()
        {
            mesh = GetComponent<TextMesh>();
        }

        void Update()
        {
            if(mesh.text != "")
            {
                timeCounter += Time.deltaTime;
                if(timeCounter > lifetime)
                {
                    timeCounter = 0;
                    mesh.text = "";
                }
            }
        }

        public static void PrintMessage(string message, float newLifetime = 1.0f)
        {
            TextMesh mesh = FindObjectOfType<TextMesh>();
            mesh.text = message;
            mesh.GetComponent<TextRendering>().lifetime = newLifetime;
        }
    }
}
