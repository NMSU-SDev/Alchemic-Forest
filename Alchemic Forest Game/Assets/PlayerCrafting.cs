using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrafting : MonoBehaviour {

    bool crafting;

    bool bridgeRune;

    // Use this for initialization
    void Start () {
        crafting = false;

        bridgeRune = false;
    }
	
	// Update is called once per frame
	void Update () {

        GameObject player = GameObject.Find("Player");
        PlayerMovement inventory = player.GetComponent<PlayerMovement>(); // !!! change me when inventory moves to own script !!!

        // check that user is on transmutation circle and which recipe to use
        // crafting for bridge
        if (crafting == true && bridgeRune == true && Input.GetKeyDown(KeyCode.Alpha3))
        {

            // check for necessary materials
            if (inventory.logCount >= 3)
            {
                inventory.logCount -= 3;
                inventory.logDisplay.text = inventory.logCount.ToString();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Transmutation"))
        {
            crafting = true;
        }//end Transmutation if

        if (other.gameObject.CompareTag("Bridge Rune"))
        {
            bridgeRune = true;
        }
    }// end of OnTriggerEnter

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Transmutation"))
        {
            crafting = false;
        }//end Transmutation if
    }// end OnTriggerEnter
}// end PlayerCrafting
