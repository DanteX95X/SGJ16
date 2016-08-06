using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Effects
{
    class IceShards : MonoBehaviour
    {
        [SerializeField]
        float lifetime = 0.1f;

        [SerializeField]
        Vector3 growth = new Vector3(1, 1, 0);

        void Start()
        {
            transform.localScale = new Vector3(0, 0, 0);
        }

        void Update()
        {
            lifetime -= Time.deltaTime;
            if (lifetime < 0)
                Destroy(gameObject);

            transform.localScale += growth * Time.deltaTime;
        }


    }
}
