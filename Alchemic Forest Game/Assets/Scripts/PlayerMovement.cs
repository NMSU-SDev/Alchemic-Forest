using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

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

    public int fishCount;
    public Text fishDisplay;

    public int torchCount;
    public Text torchDisplay;

    public int axeCount;
    public Text axeDisplay;

    public int shovelCount;
    public Text shovelDisplay;

    public int netCount;
    public Text netDisplay;

    Animator animator;

    const int IDLE = 0;
    const int BACKWARDS_MARCH = 1;
    const int LEFT_MARCH = 2;
    const int FORWARD_MARCH = 3;
    const int RIGHT_MARCH = 4;

    int currentAnimationState = IDLE;

    public bool hasAxe;
    public bool hasNet;
    public bool hasShovel;

    public int puzzleCounter = 3;
    public GameObject sRune;
    public GameObject fGem;
    public GameObject blockTree;

   void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();  // set up the Rigidbody2D force 

        logCount = 0;
        clothCount = 0;
        metalCount = 0;
        gemCount = 0;

        torchCount = 0;
        axeCount = 0;
        shovelCount = 0;
        netCount = 0;

        animator = GetComponent<Animator>();
        GameObject sRune = GameObject.Find("shovelRune");
        GameObject fGem = GameObject.Find("finalGem");
        GameObject blockTree = GameObject.Find("blockTrees");
        sRune.SetActive(false);
        fGem.SetActive(false);

       
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

        else if (!Input.anyKey)
        {
            changeState(IDLE);
        }

        if (gemCount == 4)
        {
            blockTree.SetActive(false);
        }

    }//end of FixedUpdate

    void changeState(int state)
    {
        if (currentAnimationState == state)
            return;

        switch (state)
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

        if (other.gameObject.CompareTag("chop"))
        {
            if (hasAxe == true)
            {
                other.gameObject.SetActive(false);
            }
        }

        // summer level "drop" floor challange
        if (other.gameObject.CompareTag("Drop"))
        {
            transform.position = new Vector2(19, -15);
        }

        if (other.gameObject.CompareTag("Fall Tree Puzzle"))
        {
            hasAxe = true;
            if (puzzleCounter == 3 && hasAxe == true)
            {
                other.gameObject.SetActive(false);
                puzzleCounter = puzzleCounter - 1;
            }
        }


        if (other.gameObject.CompareTag("Spring Tree Puzzle"))
        {
            hasAxe = true;
            if (puzzleCounter == 2 && hasAxe == true)
            {
                other.gameObject.SetActive(false);
                puzzleCounter = puzzleCounter - 1;
            }
        }

        if (other.gameObject.CompareTag("Summer Tree Puzzle"))
        {
            hasAxe = true;
            if (puzzleCounter == 1 && hasAxe == true)
            {
                sRune.gameObject.SetActive(true);
                other.gameObject.SetActive(false);


            }
        }



        // for the trench cover and digging
        if (other.gameObject.CompareTag("Water Cover1") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover2") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover3") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover4") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover5") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover6") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover7") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover8") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover9") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover10") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover11") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover12") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover13") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover14") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover15") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover16") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover17") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover18") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover19") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover20") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover21") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover22") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover23") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover24") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover25") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover26") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover27") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover28") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover29") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover30") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover31") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover32") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover33") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Water Cover34") && hasShovel == true)
        {
            other.gameObject.SetActive(false);
            fGem.SetActive(true);

        }



        if (other.gameObject.CompareTag("SymForFishing") && hasNet == true)
        {
            fishCount = fishCount + 1;
            fishDisplay.text = fishCount.ToString();
        }//end if

        if (other.gameObject.CompareTag("Cat") && fishCount >= 1)
        {
            other.gameObject.SetActive(false);
            fishCount -= 1;
        }

    }// end of OnTriggerEnter
}// End of PlayerMovement
