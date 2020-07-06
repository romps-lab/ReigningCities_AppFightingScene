using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {
	PhotonView view;
	public GameObject Explosion;

	// Use this for initialization
	void Start () {

		view = GetComponent<PhotonView>();
		Destroy(gameObject, 1f);
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision Col) {
		//need for both
		GetComponent<SphereCollider>().enabled = false;
		GetComponent<MeshRenderer>().enabled = false;
		if(view.isMine){

			GameObject explosion = PhotonNetwork.Instantiate("Explosion",transform.position, Quaternion.identity, 0) as GameObject;
		}

		
	}
}
