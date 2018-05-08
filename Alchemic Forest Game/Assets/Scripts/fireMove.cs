using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMove : MonoBehaviour {


    public Transform[] target;
    public float speed;

    private int current;

    
	// Use this for initialization
	void Start () {
		
	}
    
	
	// Update is called once per frame
	void Update () {
            
       if (transform.position != target[current].position)
       {
          Vector2 pos = Vector2.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
          GetComponent<Rigidbody2D>().MovePosition(pos);
       }
       else
        {
            current = (current + 1) % target.Length;
            // This equation changes the instance variable current. 
            // So current changes per frame. This causes a cycle around the array target[]. 
        }


    }


}
