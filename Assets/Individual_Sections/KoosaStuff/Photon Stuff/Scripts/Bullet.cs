using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Photon.MonoBehaviour
{
    Rigidbody bulletRB;
    bool shoot;
    public void Awake()
    { 
        bulletRB = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        //bulletRB.AddForce(transform.forward);
        //transform.Translate(0, 0, -10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("i hitting");
        if (!photonView.isMine)
            return;
        PhotonView target = collision.gameObject.GetComponent<PhotonView>();
        if(target!=null && (target.isMine || target.isSceneView))
        {
            Debug.Log("i hit something");
            if(collision.gameObject.tag=="Player")
            {
                collision.gameObject.GetComponent<PhotonView>().RPC("Reduce", PhotonTargets.All);
                GetComponent<PhotonView>().RPC("Destroy", PhotonTargets.All);
                Debug.Log("i hit player");
            }
        }
    }
    [PunRPC]
    private void Destroy()
    {
        gameObject.SetActive(false);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("i hitting");
        if (!photonView.isMine)
            return;
        PhotonView target = other.GetComponent<PhotonView>();
        if (target != null && (target.isMine || target.isSceneView))
        {
            Debug.Log("i hit something");
            if (other.tag == "Player")
            {
                other.GetComponent<PhotonView>().RPC("Reduce", PhotonTargets.All);
                GetComponent<PhotonView>().RPC("Destroy", PhotonTargets.All);
                Debug.Log("i hit player");
            }
        }
    }

}

