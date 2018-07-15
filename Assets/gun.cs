using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject bullet;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            Shooting();
		
	}
    public void Shooting()
    {
        GameObject bulletobj = PhotonNetwork.Instantiate(bullet.name, gameObject.transform.position, Quaternion.identity, 0);

    }
}
