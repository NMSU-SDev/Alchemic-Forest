using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrafting : MonoBehaviour {


    //private GameObject player;// = GameObject.Find("Player");
    //private PlayerMovement inventory;// = player.GetComponent<PlayerMovement>(); // !!! change me when inventory moves to own script !!!

    // Use this for initialization
    void Start () {
        //GameObject player = GameObject.Find("Player");
        //PlayerMovement inventory = player.GetComponent<PlayerMovement>(); // !!! change me when inventory moves to own script !!!
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = GameObject.Find("Player");

        if (other.gameObject.CompareTag("Transmutation"))
        {
            PlayerMovement inventory = player.GetComponent<PlayerMovement>(); // !!! change me when inventory moves to own script !!!

            if (inventory.logCount >= 3)
            {
                inventory.logCount -= 3;
                inventory.logDisplay.text = inventory.logCount.ToString();
            }
        }//end Transmutation if
    }// end of OnTriggerEnter
}// end PlayerCrafting
