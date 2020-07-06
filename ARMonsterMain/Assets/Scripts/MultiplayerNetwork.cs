using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MultiplayerNetwork : MonoBehaviour {
	public Text TextInfos;
	public Transform SpawnPoint1;
	public Transform SpawnPoint2;



	// Use this for initialization
	void Start () {

		PhotonNetwork.ConnectUsingSettings("v01");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PhotonNetwork.connectionStateDetailed.ToString() !="Joined"){
			TextInfos.text = PhotonNetwork.connectionStateDetailed.ToString();
		}
		else{
			//show the number of players
			TextInfos.text = "Connected to " + PhotonNetwork.room.name + ","+" Player(s) Online: "+ PhotonNetwork.room.PlayerCount;
		}

		
		
	}

	//first connect to the master
	void OnConnectedToMaster(){
		
		PhotonNetwork.JoinLobby();//when connected to the master, join the lobby
	}

	//join the lobby
	void OnJoinedLobby(){
		RoomOptions MyRoomOptions = new RoomOptions();
		MyRoomOptions.MaxPlayers = 2;//maximum 2 players in the same room at the same time
		PhotonNetwork.JoinOrCreateRoom("Room1", MyRoomOptions, TypedLobby.Default);
	}


	//spawn 2 players
	void OnJoinedRoom(){
		if (PhotonNetwork.playerList.Length > 1){
			StartCoroutine(SpawnNewPlayer());
			
		}
		else{
			StartCoroutine(SpawnNewPlayer2());
		}
		
		
	}

	IEnumerator SpawnNewPlayer(){
		yield return new WaitForSeconds(1);
		GameObject MyPlayer = PhotonNetwork.Instantiate("alienSoldier (1)", SpawnPoint1.position, Quaternion.identity, 0) as GameObject;

	}

	IEnumerator SpawnNewPlayer2(){
		yield return new WaitForSeconds(1);
		GameObject MyPlayer = PhotonNetwork.Instantiate("alienSoldier (1)", SpawnPoint2.position, Quaternion.identity, 0) as GameObject;

	}



}
