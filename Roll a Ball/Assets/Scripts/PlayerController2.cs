using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour{

	public float speed;//since public it will show as an attribute changeable in editor in unity
	public Text countText;//displays count of objects picked up
	public Text winText;//will display if all objects picked up

	private Rigidbody rb;
	public int count; //number of pick up objects picked up
	private GameObject[] gameObjectArray;

	void Start(){
		rb = GetComponent<Rigidbody>();
		
		count = 0; //setting count
		SetCountText();//updating count and potential win
		winText.text = "";//set default value of wintext
		originalPos = gameObject.transform.position;//needing for restart method to set position to center again
		gameObjectArray = GameObject.FindGameObjectsWithTag ("Pick Up");//needed for restart to enable all gems
	}

	//we want to check every frame for player input
	//apply every input as every frame as movement
	//we can use update() called before rendering a frame
	//fixedUpdate() is where physics wil be implemented
	void FixedUpdate(){
		//you can look up input documentation at unity documentation site
		//we used input get axis 
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		rb.isKinematic = false;
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); //controls movement

		rb.AddForce(movement * speed);		//to apply force on player object we can use class rigidbody's functions like addForce, note vector 3 holds x y z plot axis
	}

	//called when player object first touches a trigger collider, collider is called other, 
	//we destroy the game object that the collider is connected to and all of its componenents and all of its child components 
	//are removed off of the scene "destroyed"
	//IMPORTANT: this wont work unless you go to each game object in unity and either as a group using pre fabs
	//or individually make each check marked for isTrigger in the Box Collider section.
	//ALSO: make each individual cube or group in prefab to add component rigid body so that they become dynamic colliders vs static colliders (more optimized in cache resources)
	//ALSO: make sure to individual cube or group in prefab to have the kindematic in rigibody checked off
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false); //method called everytime player touches a trigger collider
			count = count + 1;//increment the count for every collision, we want to use Unity's UI element to display the count
			//to create UI element >hierarchy>create>UI element>text
			SetCountText();
		}
	}

	void SetCountText(){//updates count and potential win
		countText.text = "Player 2 Count: " + count.ToString();
		if (count >= 13){
			winText.text = "Player 2 Win!";
		}
	}


	public float jumpFallScalar = 2.5f;
	public float jumpLowScalar = 2f;
	void Update(){
		//jumping mechanic
		if(rb.velocity.y <0){
			rb.velocity += Vector3.up*Physics2D.gravity.y*(jumpFallScalar-1)*Time.deltaTime;
		}else if (rb.velocity.y>0 && !Input.GetButton("Jump")){
			rb.velocity += Vector3.up*Physics2D.gravity.y*(jumpLowScalar - 1)*Time.deltaTime;
		}
	}

	Vector3 originalPos;
	public void RestartPosition(){
     	rb.transform.position = originalPos;
     	rb.velocity = Vector3.zero;
     	count = 0;
     	SetCountText();
     	rb.isKinematic = true;

     	
        foreach(GameObject go in gameObjectArray)
        {
            go.SetActive (true);
        }
 	}
 	public void GoToMainMenu(){
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

 //    [SerializeField] private Text uiText;
	// [SerializeField] private float mainTimer;

	// private float timer;//what will actually be used as a countdown
	// private bool canCount = true;
	// private bool doOnce = false;

	// void Start(){
	// 	timer = mainTimer;
	// }

	// void Update(){
	// 	if(timer >= 0.0f && canCount){
	// 		timer -= Time.deltaTime;
	// 		uiText.text = timer.ToString("F");//timer is a float conveted to a string 
	// 	}else if(timer <= 0.0f && !doOnce){
	// 		canCount = false;
	// 		doOnce = true;
	// 		uiText.text = "0.00";
	// 		timer = 0.0f;
	// 	}
	// 	if(){
			
	// 	}
	// }
}