using UnityEngine;
using System.Collections;

public class FontsGetter : MonoBehaviour {

    public Font font = null;
    public Font fontTitle = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Font getFont()
    {
        return font;
    }

    public Font getFontTitle()
    {
        return fontTitle;
    }

}
