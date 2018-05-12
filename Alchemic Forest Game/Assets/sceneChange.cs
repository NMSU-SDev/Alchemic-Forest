using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneChange : MonoBehaviour {
    public Color loadToColor = Color.black;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Exit"))
        {
            Initiate.Fade("Spring Level", loadToColor, 1f);
        }
    }
}
