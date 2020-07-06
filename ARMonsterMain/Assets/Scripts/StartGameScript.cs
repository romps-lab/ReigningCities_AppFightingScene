using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour {

	// Use this for initialization
	public Button GameStartButton;
	public GameObject NetworkManagerObject;
	public GameObject placeNewButton;


	// Use this for initialization
	void Start () {
		GameStartButton.onClick.AddListener(startGame);//when click gameStartButton call startGame function
	}
	
	// game start function
	void startGame () {
		GameStartButton.gameObject.SetActive(false);
		NetworkManagerObject.SetActive(true);
		placeNewButton.gameObject.SetActive(false);
	}
}
