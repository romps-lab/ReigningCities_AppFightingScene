using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShootingScript : MonoBehaviour {
	PhotonView theView;
	public GameObject Bullet;
	public int shootingSpeed = 30;
	private bool ShootBool = true;//set the limitation of shooting speed flag

	// Use this for initialization
	void Start () {
		theView = GetComponent<PhotonView>();//get access to the game view

	}
	
	// Update is called once per frame
	void Update () {

		if((theView.isMine && (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButton("Fire"))) && ShootBool){
			ShootBool =false;
			StartCoroutine(SetShootBoolBack());

			//RPC: remote procedure call
			theView.RPC("shootBullet", PhotonTargets.All, transform.Find("ShootPosition").transform.position, transform.Find("ShootPosition").transform.rotation);
		}
		
	}

	IEnumerator SetShootBoolBack(){
		yield return new WaitForSeconds(1f);//everytime after making a shoot, needs waiting for 0.5s to make another shot
		ShootBool = true;
	}

	[PunRPC]
	void shootBullet(Vector3 Pos, Quaternion quaat){
		GameObject GO = Instantiate(Bullet, Pos, quaat) as GameObject;// when hitting space bar, there is a new bullet in the view
		GO.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.right * shootingSpeed);//let the bullet move forward;

	}
}
