using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using UnityEngine.SceneManagement;



public class GameManagers : Photon.MonoBehaviour
{
    public static GameManagers gameManagerInstance;

    // Use this for initialization
    void Awake ()
    {
        gameManagerInstance = this;

    }
	
	// Update is called once per frame
	void Update ()
    {
       
		
	}
    public enum GameStates
    {
        Starting,
        Spawning,
        Playing,
        Ending,
        Default
    }
}
