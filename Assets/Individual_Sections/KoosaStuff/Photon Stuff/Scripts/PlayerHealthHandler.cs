using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHandler : Photon.MonoBehaviour
{
    public PlayerControllerNetwork playerContoller;
    public GameObject localPlayerCanvas;
    public GameObject otherPlayerCanvas;
    public Image localPlayerHealthBar;
    public Image otherPlayerHealthBar;
    public GameObject localPlayer;

    // Use this for initialization
    void Start()
    {
        CanvasManager();
        localPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      

        if (photonView.isMine)
        {
            //localPlayerHealthBar.fillAmount -= 0.01f;
            if (Input.GetKeyDown(KeyCode.Space))
           localPlayer.GetComponent<PhotonView>().RPC("Reduce", PhotonTargets.All);
           localPlayerCanvas.SetActive(true);

        }
        else
        {
           // otherPlayerHealthBar.fillAmount -= 0.1f;
             //localPlayer.GetComponent<PhotonView>().RPC("Reduce", PhotonTargets.All);
            otherPlayerCanvas.SetActive(true);
        }
    }
    [PunRPC]
    public void Reduce()
    {
        Damage(0.1f);
    }

    public void Damage(float hit)
    {
        if (photonView.isMine)
        {
            localPlayerHealthBar.fillAmount -= hit;
            //local.SetActive(true);
        }
        else
        {
           otherPlayerHealthBar.fillAmount -= hit;
           // other.SetActive(true);
        }

    }
    public void CanvasManager()
    {
        if (photonView.isMine)
        {
            localPlayerCanvas.SetActive(true);


        }
        else
        {
            otherPlayerCanvas.SetActive(true);
        }

    }

}
