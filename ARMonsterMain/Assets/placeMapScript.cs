using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityARInterface;
using UnityEngine.SceneManagement;

public class placeMapScript : MonoBehaviour {

	public Button StartGameButton;
	public Button PlaceGameObjectButton;
	public Button PlaceNewButton;

	private ARPointCloudVisualizer ARPointCloudVisualizer;//set link between the button and the points
	private ARPlaneVisualizer ARPlaneVisualizer;


	public void onClickPlaceGameObject(){
		//when click place map button, get access to the plane and particles
		var planes = GameObject.FindGameObjectsWithTag("planeTag");
		var particles = GameObject.FindGameObjectsWithTag("particleTag");

		foreach(var plane in planes){
			Destroy(plane);
		}

		foreach(var particle in particles){
			Destroy(particle);
		}

		ARPointCloudVisualizer = GameObject.Find("AR Root").GetComponent<ARPointCloudVisualizer>();//get access to ARPointCloudVisualizer
		ARPlaneVisualizer = GameObject.Find("AR Root").GetComponent<ARPlaneVisualizer>();//get access to ARPlaneVisualizer

		Destroy(ARPointCloudVisualizer);
		Destroy(ARPlaneVisualizer);

		//after click place map button, show start game button and place new map button
		StartGameButton.gameObject.SetActive(true);
		PlaceGameObjectButton.gameObject.SetActive(false);
		PlaceNewButton.gameObject.SetActive(true);
	}


	//a new function to start a new scene
	public void OnClickPlaceNew(){
		SceneManager.LoadScene("finalProject");
	}
	
}
