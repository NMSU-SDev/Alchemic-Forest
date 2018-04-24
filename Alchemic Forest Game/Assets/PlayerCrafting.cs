using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrafting : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        PlayerMovement inventory = player.GetComponent<PlayerMovement>(); // !!! change me when inventory moves to own script !!!
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Transmutation"))
        {

        }//end Transmutation if
    }// end of OnTriggerEnter
}// end PlayerCrafting
