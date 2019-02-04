using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

	//the goal of this code is so that the camera may follow the ball for all movement BUT it does not focus on ONE surface point of the ball (equals crazy camera movement)
	public GameObject player;
	private Vector3 offset;
    // Start is called before the first frame update
    void Start(){
        offset = transform.position - player.transform.position; //offset is private bc we can set offset here in the script
        //take current transform pos of camera and subtract transform pos of player to find difference in distance
    }
    void LateUpdate(){
    	transform.position = player.transform.position + offset;
        //every frame positon set to player positon + the offset
        //we want to use this in LateUpdate which runs every frame but it is guaranteed to run after all items have been updated
    }

    // Update is called once per frame
    void Update() {//runs for every frame
    }
}
