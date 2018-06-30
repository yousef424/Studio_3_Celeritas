using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{
    [SerializeField]
    private Text _roomName;
    private Text RoomName
    {
        get { return _roomName; }
    }


    public void CreatRoom()
    {
        if (PhotonNetwork.CreateRoom(RoomName.text))
            Debug.Log("Creating Room");

        else
            Debug.Log("Unable To Creat Room");
    }
    private void OnPhotonCreatRoomFailed(object[] codeAndMessage)
    {
        Debug.Log("failed to creat room" + codeAndMessage[1]);
    }
    private void OnCreatedRoom()
    {
        Debug.Log( RoomName.text+" created successfully");
    }






}
