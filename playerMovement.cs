using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
	public float speed;

	void Start(){
		
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical   = Input.GetAxis ("Vertical");
		transform.Translate(new Vector3 (moveHorizontal, moveVertical) *Time.deltaTime * speed);

	}
}
