using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementAlienScript : MonoBehaviour {

	PhotonView theView;
	Rigidbody rb;
	public float movementSpeed = 1;//make it adjustable outside the script

	// Use this for initialization
	void Start () {
		theView = GetComponent<PhotonView>();
		rb = GetComponent<Rigidbody>();
	}
	
	// Character movement: when hitting W/A/S/D the character will move forward/left/backward/
	void Update()
	{
		if (theView.isMine){
			//keyboard control
			var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
			var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

			transform.Rotate(0, x, 0);
			transform.Translate(0, 0, z);

			//mobile control
			float xValue = CrossPlatformInputManager.GetAxis("Horizontal");
			float yValue = CrossPlatformInputManager.GetAxis("Vertical");

			Vector3 movement = new Vector3(xValue, 0, yValue );//only change x and z values form the game object
			rb.velocity = movement * movementSpeed; //mobile control speed

			if(xValue != 0 && yValue != 0){
				transform.eulerAngles = new Vector3(transform.eulerAngles.z, Mathf.Atan2(xValue, yValue)*Mathf.Rad2Deg, transform.eulerAngles.x);

			}



		}
		
	}
}
