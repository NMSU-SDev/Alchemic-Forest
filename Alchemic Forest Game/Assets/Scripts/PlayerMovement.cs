using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigid2D;
    public int logCount;// dependency in PlayerCrafting.cs

    public float speed;
    public Text logDisplay;

    public int clothCount;
    public Text clothDisplay;

    public int metalCount;
    public Text metalDisplay;

    public int gemCount;
    public Text gemDisplay;

    Animator animator;

    const int IDLE = 0;
    const int BACKWARDS_MARCH = 1;
    const int LEFT_MARCH = 2;
    const int FORWARD_MARCH = 3;
    const int RIGHT_MARCH = 4;

    int currentAnimationState = IDLE;

    public bool hasAxe;

    public int puzzleCount = 4;
    public GameObject sRune;


    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D> ();  // set up the Rigidbody2D force 

        
        logCount = 0;
        clothCount = 0;
        metalCount = 0;
        gemCount = 0;

        bool hasAxe = false;// for testing when inventory is fully implemented this will be set there
        GameObject sRune = GameObject.Find("shovelRune");

        sRune.SetActive(false);
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
 
        if (other.gameObject.CompareTag("Log"))
        {
            other.gameObject.SetActive(false);// deactivate the object.This will make it dissapear from the game.
            logCount = logCount + 1;
            logDisplay.text = logCount.ToString();
        }//end if

        if (other.gameObject.CompareTag("Cloth"))
        {
            other.gameObject.SetActive(false);// deactivate the object.This will make it dissapear from the game.
            clothCount = clothCount + 1;
            clothDisplay.text = clothCount.ToString();
        }//end if

        if (other.gameObject.CompareTag("Metal"))
        {
            other.gameObject.SetActive(false);// deactivate the object.This will make it dissapear from the game.
            metalCount = metalCount + 1;
            metalDisplay.text = metalCount.ToString();
        }//end if

        if (other.gameObject.CompareTag("Gem"))
        {
            other.gameObject.SetActive(false);// deactivate the object.This will make it dissapear from the game.
            gemCount = gemCount + 1;
            gemDisplay.text = gemCount.ToString();
        }//end if

        if(other.gameObject.CompareTag("chop"))
        {
            //hasAxe = true;
            if (hasAxe == true)
            {
                other.gameObject.SetActive(false);
            }
        }


        if (other.gameObject.CompareTag("Fall Tree Puzzle"))
        {
            hasAxe = true;
            if (puzzleCount == 4 && hasAxe == true)
            {
                other.gameObject.SetActive(false);
                puzzleCount = puzzleCount - 1;
            }
        }

         if (other.gameObject.CompareTag("Winter Tree Puzzle"))
        {
            hasAxe = true;
            if (puzzleCount == 3 && hasAxe == true)
            {
                other.gameObject.SetActive(false);
                puzzleCount = puzzleCount - 1;
            }
        }

        if (other.gameObject.CompareTag("Spring Tree Puzzle"))
        {
            hasAxe = true;
            if (puzzleCount == 2 && hasAxe == true)
            {
                other.gameObject.SetActive(false);
                puzzleCount = puzzleCount - 1;
            }
        }

        if (other.gameObject.CompareTag("Summer Tree Puzzle"))
        {
            hasAxe = true;
            if (puzzleCount == 1 && hasAxe == true)
            {
                sRune.gameObject.SetActive(true);
                other.gameObject.SetActive(false);
              //  GameObject sRune = GameObject.Find("ShovelRune");
               
            }
        }
        // summer level "drop" floor challange
        if (other.gameObject.CompareTag("Drop"))
        {
            transform.position = new Vector2(19,-15);
        }
    }// end of OnTriggerEnter
}// End of PlayerMovement
