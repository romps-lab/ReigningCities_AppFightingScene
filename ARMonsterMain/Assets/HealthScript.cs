using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public int health = 100;//default health is 100
	PhotonView view;
	Text myHealth;
	Text otherHealth;
	Image healthBar;
	Image healthBarOther;

	// Use this for initialization
	void Start () {
		//get the view and health component
		view = GetComponent<PhotonView>();
		myHealth = GameObject.Find("myHealth").GetComponent<Text>();
		otherHealth = GameObject.Find("otherHealth").GetComponent<Text>();

		healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
		healthBarOther = GameObject.Find("HealthBarOther").GetComponent<Image>();

		healthBar.fillAmount = health/100f; //value form 0 to 1
		healthBarOther.fillAmount = health/100f; 

	}

	void OnCollisionEnter(Collision Col){
		if(Col.gameObject.tag == "Bullet" && view.isMine){//when object collides with bullet and the view is mine 
			health -= 10;
			myHealth.text = "player 1:"+ health + "%";
			view.RPC("damageOther", PhotonTargets.Others, health);
			healthBar.fillAmount = health/100f;

		}
	}
	
	// destory the tank when health hits 0
	void Update () {
		if(health <= 0){
			view.RPC("destoryCa", PhotonTargets.All);
		}
	}


	[PunRPC]
	void destoryCa(){
		Destroy(gameObject);

	}



	[PunRPC]
	void damageOther(int health){
		otherHealth.text = "player 2:"+ health + "%";
		healthBarOther.fillAmount = health/100f; 

	}
}
