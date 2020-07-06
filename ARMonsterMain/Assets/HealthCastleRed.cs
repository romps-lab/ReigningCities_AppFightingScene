using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCastleRed : MonoBehaviour {
	public int healthCastleRed = 100;
	PhotonView view;


	// Use this for initialization
	void Start () {
		view = GetComponent<PhotonView>();

	}

	void OnCollisionEnter(Collision Col){
		if(Col.gameObject.tag == "Bullet" && view.isMine){
			healthCastleRed -= 10;
			view.RPC("damageCastleRed", PhotonTargets.Others, healthCastleRed);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (healthCastleRed <= 0){
			view.RPC("destroyCR", PhotonTargets.All);
		}
	}

	[PunRPC]
	void destroyCR(){
		Destroy(gameObject);
	}

	[PunRPC]
	void damageCastleRed(int healthCastleRed){

	}
}
