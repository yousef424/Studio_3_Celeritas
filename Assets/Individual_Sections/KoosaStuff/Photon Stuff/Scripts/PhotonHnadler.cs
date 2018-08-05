using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhotonHnadler : MonoBehaviour
{
    public static PhotonHnadler instance;
    public GameObject[] redSpawnPoints;
    public GameObject[] blueSpawnPoints;
    public Text roomNameJoined;
    public bool roomJoinedExists;
    public Text roomNameCreated;
    public bool roomCreatedExists;
    public bool arab;
    public bool russian;
    public bool korean;
    public bool american;
    public int team;
    public int state;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }
    [PunRPC]
    public void Play()
    {
        this.GetComponent<PhotonView>().RPC("StartGame", PhotonTargets.All);

    }
    [PunRPC]
    public void StartGame()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
    [PunRPC]
    public void SelectHero()
    {
        PhotonNetwork.LoadLevel("HeroSelect");
    }
    [PunRPC]
    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == "GameScene")
        {
            if(arab)
            SpawnPlayer(team,"arab");
            if(american)
                SpawnPlayer(team, "american");
            if (korean)
                SpawnPlayer(team, "korean");
            if (russian)
                SpawnPlayer(team, "russian");
        }

    }
    void OnGUI()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HeroSelect"))
            switch (state)
            {
                case 0:

                    if (GUI.Button(new Rect(40, 40, 100, 20), "Kareem"))
                    {
                        arab = true;
                        russian = false;
                        american = false;
                        korean = false;
                    }
                    if (GUI.Button(new Rect(40, 70, 100, 20), "Yuri"))
                    {
                        russian = true;
                        arab = false;
                        american = false;
                        korean = false;
                    }
                    if (GUI.Button(new Rect(40, 100, 100, 20), "Xin Xaouh"))
                    {
                        korean = true;
                        arab = false;
                        american = false;
                        russian = false;
                    }
                    if (GUI.Button(new Rect(40, 130, 100, 20), "Jim Bab"))
                    {
                        american = true;
                        arab = false;
                        russian = false;
                        korean = false;
                    }
                    if (korean || american || arab || russian)
                    {
                        if (GUI.Button(new Rect(130, 200, 100, 20), "Play"))
                        {
                            Play();
                        }
                    }

                    break;
            case 1:
                //InGame

                break;
        }
    }









        private void SpawnPlayer(int team,string character)
        {
        redSpawnPoints = GameObject.FindGameObjectsWithTag("redspawn");
        blueSpawnPoints = GameObject.FindGameObjectsWithTag("bluespawn");

        //playerSpawnPoints = GameObject.FindObjectsOfType<PlayerSpawnPoint>();
        GameObject mySpawnPoint = redSpawnPoints[Random.Range(0, redSpawnPoints.Length)];
       GameObject myLocalPlayer = PhotonNetwork.Instantiate(character, mySpawnPoint.transform.position, Quaternion.identity, 0);
        }
    public void onClickJoinRoom()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].Name == roomNameJoined.text)
            {
                Debug.Log("Room Exists");
                roomJoinedExists = true;
                break;
            }
        }

        if (roomJoinedExists)
        {
            PhotonNetwork.JoinRoom(roomNameJoined.text);
            Debug.Log("Joining " + roomNameJoined + " Room");
        }
        if (!roomJoinedExists)
            Debug.Log(roomNameJoined.text + " Room doesn't exist or can't be joined");


        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
    }
    private void OnJoinedRoom()
    {
        Debug.Log(roomNameJoined.text + " Room Joined Successfully");
        if ((PhotonNetwork.playerList.Length == 4 || PhotonNetwork.playerList.Length==1 || PhotonNetwork.playerList.Length == 2))
        {
            this.GetComponent<PhotonView>().RPC("SelectHero", PhotonTargets.All);
        }
    }
    public void CreatRoom()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].Name == roomNameCreated.text)
            {
                Debug.Log(roomNameCreated + " Room Already Exists!!!!!");
                roomCreatedExists = true;
                break;
            }
        }
        if (roomNameCreated.text.Length >= 4 && !roomCreatedExists)
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
	
	

