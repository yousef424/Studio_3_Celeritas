using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class PlayerControllerNetwork : Photon.MonoBehaviour
{

    public PhotonView playerPhotonView;
    public float speed;
    private float rotSpeed=5f;
    private Vector3 pos;
    public Quaternion rot;
    private float smoothing = 0.05f;
    public bool flagTest;
    public GameObject playerCamera;
    public GameObject sceneCam;
    public Text playerNameText;
    public Text otherPlayerName;
    public List<GameObject> allies = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject bullet;
    float x;
    public void Awake()
    { 
        sceneCam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void Update()
    {
        //Debug.Log(playerPhotonView.isMine);
        if (!flagTest)
        {
            if (playerPhotonView.isMine)
            {
                Movement();
                playerCamera.SetActive(true);
                sceneCam.SetActive(false);
                playerNameText.text = PhotonNetwork.playerName;
                otherPlayerName.text = PhotonNetwork.playerName;
                // playerNameText.text = PhotonNetwork.player.NickName;
            }
            else
            {
                SmoothMovement();
                playerNameText.text = photonView.owner.name;
                playerNameText.text = photonView.owner.name;
                otherPlayerName.text = photonView.owner.name;
                playerNameText.color = Color.red;
                otherPlayerName.color = Color.red;

            }
        }
        else Movement();


    }
    public void Movement()
    {
         x = Input.GetAxis("Mouse X");
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        //transform.Translate(0, z, 0);
    }
    public void SmoothMovement()
    {
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * smoothing* PhotonNetwork.networkingPeer.RoundTripTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * smoothing* PhotonNetwork.networkingPeer.RoundTripTime);
    }
    public void OnPhotonSerializeView(PhotonStream photonStream,PhotonMessageInfo photonMessage)
    {
        if(photonStream.isWriting)
        {
            photonStream.SendNext(transform.position);
            photonStream.SendNext(transform.rotation);
        }
        else
        {
            pos = (Vector3)photonStream.ReceiveNext();
            rot = (Quaternion)photonStream.ReceiveNext();
        }
    }
    public void Shooting()
    {
        GameObject bulletobj = PhotonNetwork.Instantiate(bullet.name, gameObject.transform.forward, Quaternion.identity,0);

    }
}
