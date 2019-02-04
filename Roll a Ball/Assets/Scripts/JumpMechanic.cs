using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class JumpMechanic : MonoBehaviour{

	[Range(1,10)]
	public float jumpVelocity;
	private float canJump = 0f;
 
	void Update(){
		if (Input.GetButtonDown("Jump")){
			GetComponent<Rigidbody>().velocity = Vector3.up*jumpVelocity;
		}
		 // // then in update
 
		 // if (Input.GetMouseButtonDown(0) && Time.time > canJump){
		  
		 //     velocity = rigidbody.velocity;
		 //     velocity.y = jumpSpeed;
		 //     rigidbody.velocity = velocity;
		 //     canJump = Time.time + 1.5f;    // whatever time a jump takes
		 // }
	}
}