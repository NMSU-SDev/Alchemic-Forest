using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrafting : MonoBehaviour {

    bool crafting;

    // Use this for initialization
    void Start () {
        crafting = false;
    }
	
	// Update is called once per frame
	void Update () {

        GameObject player = GameObject.Find("Player");
        PlayerMovement inventory = player.GetComponent<PlayerMovement>(); // !!! change me when inventory moves to own script !!!

        if (crafting == true && Input.GetKeyDown(KeyCode.Alpha3))
        {

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
    }// end of OnTriggerEnter
}// end PlayerCrafting
