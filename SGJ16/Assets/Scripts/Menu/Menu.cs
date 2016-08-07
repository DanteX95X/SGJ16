using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.Game;


public class Menu : MonoBehaviour {


    public Texture[] textures;


    public float BUTTONWIDTH;
    public float BUTTONHEIGHT;
    public float LOGOWIDTH;
    public float LOGOHEIGHT;
    public float FIRSTBUTTONPOSX;
    public float FIRSTBUTTONPOSY;
    public float FIRSTPOSX;
    public float FIRSTPOSY;

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
        BUTTONWIDTH = Screen.width / 2f;
        BUTTONHEIGHT = Screen.height / 10f;
        LOGOWIDTH = 11*(Screen.width / 12f);
        LOGOHEIGHT = 10 * (Screen.height / 36f);
        FIRSTBUTTONPOSX = Screen.width/2f - BUTTONWIDTH/2; //this is a BUTTONWITH
        FIRSTBUTTONPOSY = Screen.height / 10f;
        FIRSTPOSX = Screen.width / 24f;
        FIRSTPOSY = Screen.height / 10f;

    }  

    public void OnGUI()
    {



        GUIStyle style = GUIStyle.none;
        style.alignment = TextAnchor.MiddleCenter;
        style.stretchWidth = true;
        style.stretchHeight = true;
        //GUI.Box(new Rect(FIRSTPOSX, FIRSTPOSY, LOGOWIDTH, LOGOHEIGHT), textures[3], style);
        GUI.DrawTexture(new Rect(FIRSTPOSX + LOGOWIDTH*0.1f, FIRSTPOSY, LOGOWIDTH*0.8f, LOGOHEIGHT), textures[3]);

        if (GUI.Button(new Rect(FIRSTBUTTONPOSX, 2 * FIRSTPOSY + LOGOHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), textures[0], style))
        {
            SceneManager.LoadScene(1);

        }
        if (GUI.Button(new Rect(FIRSTBUTTONPOSX, 2 * FIRSTPOSY + LOGOHEIGHT + BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), textures[1], style))
        {

        }

        if (GUI.Button(new Rect(FIRSTBUTTONPOSX, 2 * FIRSTPOSY + LOGOHEIGHT + 2* BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), textures[2], style))
        {
            Application.Quit();
        }
    }
}
