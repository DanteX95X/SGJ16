using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Vector3 position;

	void Start ()
    {
        position = gameObject.transform.position;
        Debug.Log("player spawned");
	}
	
	void Update ()
    {
        HandleInput();
	}

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
            position.y += 1;
        if (Input.GetKeyDown(KeyCode.S))
            position.y -= 1;
        if (Input.GetKeyDown(KeyCode.A))
            position.x -= 1;
        if (Input.GetKeyDown(KeyCode.D))
            position.x += 1;

        gameObject.transform.position = position;
    }
}
