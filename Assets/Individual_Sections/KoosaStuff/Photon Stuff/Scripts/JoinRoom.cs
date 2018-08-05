using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviour
{
    public Text roomNameJoined;
    public bool roomExists;

    public void onClickJoinRoom()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].Name == roomNameJoined.text)
            {
                Debug.Log("Room Exists");
                roomExists = true;
                break;
            }
        }

        if (roomExists)
        {
            PhotonNetwork.JoinRoom(roomNameJoined.text);
            Debug.Log("Joining " + roomNameJoined + " Room");
        }
        if (!roomExists)
            Debug.Log(roomNameJoined.text+" Room doesn't exist or can't be joined");

        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        
        

    }
    private void OnJoinedRoom()
    {
        Debug.Log(roomNameJoined.text + " Room Joined Successfully");
        if (PhotonNetwork.playerList.Length == 1 & PhotonNetwork.isMasterClient == true)
        {
            this.GetComponent<PhotonView>().RPC("StartGame", PhotonTargets.All);
        }
    }
    

	








}
