using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Effects
{
    class Vortex : MonoBehaviour
    {
        [SerializeField]
        float rotationSpeed = 500.0f;

        [SerializeField]
        float lifetime = 0.5f;

        Quaternion rotation;
        void Start()
        {
            rotation = Quaternion.Euler(0, 0, 179);
        }

        void Update()
        {
            lifetime -= Time.deltaTime;
            if (lifetime < 0)
                Destroy(gameObject);

            if (rotation != gameObject.transform.rotation)
            {
                //print(rotation.eulerAngles.z);
                if (Mathf.Abs(rotation.eulerAngles.z - gameObject.transform.rotation.eulerAngles.z) < 5)
                {
                    gameObject.transform.rotation = rotation;
                    //eulerRotation = new Vector3(0, 0, rotation.eulerAngles.z);
                }
                else
                {
                    print(transform.rotation.eulerAngles.z);
                    float step = rotationSpeed * Time.deltaTime;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step);
                }

            }
        }
    }
}
