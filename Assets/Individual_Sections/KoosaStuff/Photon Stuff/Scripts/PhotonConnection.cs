﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnection : MonoBehaviour
{
    public string versionName = "0.1";
	// Use this for initialization
	void Start ()
    {
        Debug.Log("connecting to master server");
        PhotonNetwork.ConnectUsingSettings(versionName);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void PhotonConnected()
    {
        Debug.Log("connecting to master server");
        PhotonNetwork.ConnectUsingSettings(versionName);
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
    private void OnDisconnectedFromPhoton()
    {

    }

}