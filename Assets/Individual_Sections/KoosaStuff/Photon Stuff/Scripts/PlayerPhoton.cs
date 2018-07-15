using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPhoton :Photon.MonoBehaviour
{
    public static PlayerPhoton playerPhotonInstance = new PlayerPhoton();
    public string playerName;
    public string playerPassword;
    public bool blue;
    public bool red;
   // public PhotonView photonviewplayerphoton;
 

    void Awake()
    {
        playerPhotonInstance = this;
        if (playerPhotonInstance != null && playerPhotonInstance != this)
        {
            Destroy(this.gameObject);
        }

        playerPhotonInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void SetPlayerStats(string userNameToSet, string passWordToSet)
    {
        PhotonNetwork.playerName = userNameToSet;
        PhotonNetwork.player.NickName = userNameToSet;
        playerName = userNameToSet;
        playerPassword = passWordToSet;
    }
    [PunRPC]
    public void RedTeam()
    {
        
            red = true;
            blue = false;
      //  photonviewplayerphoton.RPC("RedTeam", PhotonTargets.AllBuffered, 0);
        
    }
    [PunRPC]
    public void BlueTeam()
    {
        
            red = false;
            blue = true;
      //  photonviewplayerphoton.RPC("BlueTeam", PhotonTargets.AllBuffered, 0);
    }
}
