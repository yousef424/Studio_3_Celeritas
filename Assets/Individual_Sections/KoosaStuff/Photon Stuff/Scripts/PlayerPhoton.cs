using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhoton : MonoBehaviour
{
    public static PlayerPhoton playerPhotonInstance;
    public string PlayerName { get; private set; }

    void Awake()
    {
        playerPhotonInstance = this;
        PlayerName = "yousef" + Random.Range(400, 5000);
        Debug.Log(PlayerName);
    }
}
