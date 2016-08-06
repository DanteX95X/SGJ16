using UnityEngine;
using System.Collections;

public class MaterialChanging : MonoBehaviour {


    [SerializeField]
    Material material = null;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Changer()
    {
        GetComponent<Renderer>().material = material;
    }
}
