using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{
    
    public Text roomNameCreated;
    public bool roomExists;

    public void CreatRoom()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].Name == roomNameCreated.text)
            {
                Debug.Log( roomNameCreated+" Room Already Exists!!!!!");
                roomExists = true;
                break;
            }
        }
            if (roomNameCreated.text.Length >= 4 && !roomExists)
            {
                PhotonNetwork.CreateRoom(roomNameCreated.text, new RoomOptions() { MaxPlayers = 4 }, TypedLobby.Default);
                Debug.Log("Creating Room");
            }

            else
                Debug.Log("Unable To Creat Room");
        
    }
    private void OnPhotonCreatRoomFailed(object[] codeAndMessage)
    {
        Debug.Log("Failed To Creat Room" + codeAndMessage[1]);
    }
    private void OnCreatedRoom()
    {
        Debug.Log(roomNameCreated.text + " Room Created Successfully");
    }

}
