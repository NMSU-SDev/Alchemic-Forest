using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrafting : MonoBehaviour {

    bool crafting;

    bool bridgeRune, torchRune, axeRune, netRune, shovelRune;
    // Use this for initialization
    void Start () {
        crafting = false;
        bridgeRune = false;
        torchRune = false;
        axeRune = false;
        netRune = false;
        shovelRune = false;
    }
	
	// Update is called once per frame
	void Update () {

        GameObject player = GameObject.Find("Player");
        PlayerMovement inventory = player.GetComponent<PlayerMovement>(); // !!! change me when inventory moves to own script !!!

        int bridges = 0;

        // check that user is on transmutation circle and which recipe to use
        // crafting for bridge
        if (crafting == true && bridgeRune == true && Input.GetKeyDown(KeyCode.Alpha3))
        {

            // check for necessary materials
            if (inventory.logCount >= 3)
            {
                inventory.logCount -= 3;
                inventory.logDisplay.text = inventory.logCount.ToString();

                switch (bridges)
                {
                    case 0:
                        GameObject.FindWithTag("Bridge Cover").SetActive(false);
                        break;

                    case 1:
                        GameObject.FindWithTag("Bridge Cover2").SetActive(false);
                        break;

                    case 2:
                        GameObject.FindWithTag("Bridge Cover3").SetActive(false);
                        break;

                    default :
                        break;
                }
            }
        }

        if (crafting == true && torchRune == true && Input.GetKeyDown(KeyCode.Alpha1))
        {

            // check for necessary materials
            if (inventory.logCount >= 1 && inventory.clothCount >= 2)
            {
                inventory.logCount -= 1;
                inventory.clothCount -= 2;
                inventory.logDisplay.text = inventory.logCount.ToString();
                inventory.clothDisplay.text = inventory.clothCount.ToString();
            }
        }

        if (crafting == true && axeRune == true && Input.GetKeyDown(KeyCode.Alpha2))
        {

            // check for necessary materials
            if (inventory.logCount >= 1 && inventory.metalCount >= 2)
            {
                inventory.logCount -= 1;
                inventory.metalCount -= 2;
                inventory.logDisplay.text = inventory.logCount.ToString();
                inventory.metalDisplay.text = inventory.metalCount.ToString();

                inventory.hasAxe = true;
            }
        }

        if (crafting == true && netRune == true && Input.GetKeyDown(KeyCode.Alpha4))
        {

            // check for necessary materials
            if (inventory.logCount >= 2 && inventory.clothCount >= 3)
            {
                inventory.logCount -= 2;
                inventory.clothCount -= 3;
                inventory.logDisplay.text = inventory.logCount.ToString();
                inventory.clothDisplay.text = inventory.clothCount.ToString();
            }
        }

        if (crafting == true && shovelRune == true && Input.GetKeyDown(KeyCode.Alpha5))
        {

            // check for necessary materials
            if (inventory.logCount >= 2 && inventory.metalCount >= 3)
            {
                inventory.logCount -= 2;
                inventory.metalCount -= 3;
                inventory.logDisplay.text = inventory.logCount.ToString();
                inventory.metalDisplay.text = inventory.metalCount.ToString();
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
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Torch Rune"))
        {
            torchRune = true;
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Axe Rune"))
        {
            axeRune = true;
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Net Rune"))
        {
            netRune = true;
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Shovel Rune"))
        {
            shovelRune = true;
            other.gameObject.SetActive(false);
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
