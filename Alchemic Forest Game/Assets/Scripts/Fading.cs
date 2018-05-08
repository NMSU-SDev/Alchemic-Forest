using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexcture;
    public float fadeSpeed = 0.0f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;   // direction of fade -1 = in, 1 = out

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        //set GUI color
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha); // set alpha value
        GUI.depth = drawDepth;  //make sure black texture renders on top
        GUI.DrawTexture ( new Rect(0, 0, Screen.width, Screen.height), fadeOutTexcture); //make texture fit screen
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);

    }


}
