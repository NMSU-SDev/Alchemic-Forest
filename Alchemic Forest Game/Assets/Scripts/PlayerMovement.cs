using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigid2D;
    private int logCount;

    public float speed;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D> ();  // set up the Rigidbody2D force 
        logCount = 0;
    }// end of Start

    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(Horizontal, Vertical);
        rigid2D.AddForce(move * speed);
    }// end of FixedUpdate

    // Upon collision with another trigger game object the script will enter this method.
    // This method will be used to identify the object by tags and preform nessasary actions.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Log"))
        {
            other.gameObject.SetActive(false);// deactivate the object.This will make it dissapear from the game.
            logCount = logCount + 1;

        }//end if
    }// end of OnTriggerEnter
}// End of PlayerMovement
