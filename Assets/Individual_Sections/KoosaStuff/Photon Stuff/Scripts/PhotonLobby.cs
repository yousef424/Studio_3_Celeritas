using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Debug.Log("connecting to master server");
        PhotonNetwork.ConnectUsingSettings("game mode");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnConnectedToMaster()
    {
        Debug.Log("Connecting to MasterClient");
        PhotonNetwork.playerName = PlayerPhoton.playerPhotonInstance.PlayerName;
        PhotonNetwork.JoinLobby(TypedLobby.Default);

    }
    private void OnJoinedLobby()
    {
        Debug.Log("lobby has been joined");
    }
}
