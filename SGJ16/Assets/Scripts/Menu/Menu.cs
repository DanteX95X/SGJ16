using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.Game;


public class Menu : MonoBehaviour {


    public Texture[] textures;


    public float BUTTONWIDTH;
    public float BUTTONHEIGHT;
    public float FIRSTBUTTONPOSX;
    public float FIRSTBUTTONPOSY;

    // Use this for initialization
    void Start ()
    {
        CheckResolution();
        textures = GetComponent<ButtonsTextures>().buttonTextures;
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckResolution();
	}   

    void CheckResolution()
    {
        BUTTONWIDTH = Screen.width / 2;
        BUTTONHEIGHT = Screen.height / 5;
        FIRSTBUTTONPOSX = Screen.width/2 - BUTTONWIDTH/2; //this is a BUTTONWITH
        FIRSTBUTTONPOSY = Screen.height / 10;
    }  

    public void OnGUI()
    {


        GUIStyle style = GUIStyle.none;
        style.alignment = TextAnchor.MiddleCenter;

        if (GUI.Button(new Rect(FIRSTBUTTONPOSX, FIRSTBUTTONPOSY, BUTTONWIDTH, BUTTONHEIGHT), textures[0], style))
        {
            SceneManager.LoadScene(1);

        }
        if (GUI.Button(new Rect(FIRSTBUTTONPOSX, 2*FIRSTBUTTONPOSY + BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), textures[1], style))
        {

        }

        if (GUI.Button(new Rect(FIRSTBUTTONPOSX, 3 * FIRSTBUTTONPOSY + 2*BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), textures[2], style))
        {
            Application.Quit();
        }
    }
}
