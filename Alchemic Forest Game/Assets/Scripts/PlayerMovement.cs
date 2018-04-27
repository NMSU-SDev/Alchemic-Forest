using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigid2D;
    private int logCount;

    public float speed;
    public Text logDisplay;

    Animator animator;

    const int IDLE = 0;
    const int BACKWARDS_MARCH = 1;
    const int LEFT_MARCH = 2;
    const int FORWARD_MARCH = 3;
    const int RIGHT_MARCH = 4;

    int currentAnimationState = IDLE;

    

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D> ();  // set up the Rigidbody2D force 
        logCount = 0;
        animator = GetComponent<Animator>();
    }// end of Start

    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(Horizontal, Vertical);
        rigid2D.AddForce(move * speed);
        
        
        if (Input.GetKey(KeyCode.UpArrow))
        {

            changeState(BACKWARDS_MARCH);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            changeState(LEFT_MARCH);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            changeState(RIGHT_MARCH);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            changeState(FORWARD_MARCH);
        }

        else if(!Input.anyKey)
        {
           changeState(IDLE);
        }
    }//end of FixedUpdate

        void changeState(int state)
        {
            if (currentAnimationState == state)
                return;

            switch(state)
            {
                case IDLE:
                    animator.SetInteger("state", IDLE);
                    break;

                case BACKWARDS_MARCH:
                    animator.SetInteger("state", BACKWARDS_MARCH);
                    break;

                case LEFT_MARCH:
                    animator.SetInteger("state", LEFT_MARCH);
                    break;

                case FORWARD_MARCH:
                    animator.SetInteger("state", FORWARD_MARCH);
                    break;

                case RIGHT_MARCH:
                    animator.SetInteger("state", RIGHT_MARCH);
                    break;
            }

            currentAnimationState = state;

        }//end of changeState


    // Upon collision with another trigger game object the script will enter this method.
    // This method will be used to identify the object by tags and preform nessasary actions.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Log"))
        {
            other.gameObject.SetActive(false);// deactivate the object.This will make it dissapear from the game.
            logCount = logCount + 1;
            logDisplay.text = logCount.ToString();
        }//end if

        public bool hasAxe = false;// for testing when inventory is fully implemented this will be set there
        if(other.gameObject.CompareTag("chop"))
        {
            if (hasAxe == true)
            {
                other.gameObject.SetActive(false);
            }
        }
    }// end of OnTriggerEnter
}// End of PlayerMovement
