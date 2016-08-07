using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ButtonsTextures : MonoBehaviour {

    [SerializeField]
    public Texture[] buttonTextures = null;
    public Texture[] buttonTexturesActive = null;    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Texture GetTexture(int i)
    {
        return buttonTextures[i];
    }

    public Texture GetTextureActive(int i)
    {
        return buttonTexturesActive[i];
    }
}
