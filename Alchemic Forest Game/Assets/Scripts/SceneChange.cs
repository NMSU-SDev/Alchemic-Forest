using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour {
    public Color loadToColor = Color.black;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            Initiate.Fade("Summer", loadToColor, 1f);

        }
    }

}
