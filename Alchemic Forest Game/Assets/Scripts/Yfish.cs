using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yfish : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;

    private bool facingRight;

    [SerializeField]
    private Collider2D other;

    // Use this for initialization
    void Start()
    {

        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // float horizontal = Input.GetAxis("Horizontal");
        // horizontal here is the value in Transform Scale X. 


        // HandleMovement(horizontal);

        Move();


        // Flip(horizontal);

        OnTriggerEnter2D(other);


    }

    /*
    private void HandleMovement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));


    }

    */

    /*
    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;

        }

    }
    */

    public void Move()
    {
        myAnimator.SetFloat("speed", 1);

        transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
    }

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerEnter(other);
    }

    private void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "edge")
        {
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;

        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        // These three arguments stand for three axes. 

    }

}
