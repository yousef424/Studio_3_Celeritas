using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonHnadler : MonoBehaviour
{
    public static PhotonHnadler instance;
    public GameObject playerGame;

    // Use this for initialization
    void Awake ()
    {

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;

    }
    public void LoadLevel()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
    private void OnSceneFinishedLoading(Scene scene,LoadSceneMode sceneMode)
    {
        if(scene.name=="GameScene")
        {
            SpawnPlayer();
        }

    }
    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(playerGame.name, playerGame.transform.position, Quaternion.identity, 0);
    }
	
	
}
