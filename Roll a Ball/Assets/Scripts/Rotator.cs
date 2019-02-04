using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	//this code is for the pick up cube, going to give it static movement 

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (15,30,45)*Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
