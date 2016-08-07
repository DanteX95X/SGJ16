using UnityEngine;
using System.Collections;

namespace Assets.Scripts.States
{
    public class Credits : State
    {

        public float BUTTONWIDTH;
        public float BUTTONHEIGHT;
        public float FIRSTPOSX;
        public float FIRSTPOSY;

        public override void Init()
        {
            Debug.Log("Credits");
        }

        public override void UpdateLoop()
        {
            CheckResolution();
        }

        void CheckResolution()
        {
            BUTTONWIDTH = Screen.width / 2f;
            BUTTONHEIGHT = Screen.height / 10f;
            FIRSTPOSX = Screen.width / 24f;
            FIRSTPOSY = Screen.height / 24f;

        }

        public void OnGUI()
        {

            GUIStyle style = GUIStyle.none;
            style.alignment = TextAnchor.MiddleCenter;
            style.stretchWidth = true;
            style.stretchHeight = true;

            GUI.DrawTexture(new Rect(FIRSTPOSX, FIRSTPOSY, 11*(Screen.width/12), Screen.height*0.6f), GetComponent<ButtonsTextures>().buttonTextures[5]);

            if (GUI.Button(new Rect(Screen.width*0.5f - BUTTONWIDTH*0.5f, Screen.height * 0.8f, BUTTONWIDTH, BUTTONHEIGHT), GetComponent<ButtonsTextures>().buttonTextures[6], style))
            {
                ChangeState<Menu>();

            }
        }


    }

}