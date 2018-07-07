using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    //
    public float movementSpeed;
    private Rigidbody rB;

    public float fAndB;
    public float rAndL;
    //
    bool onGround = true;
    float jumpHeight = 5f;
    //
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw;
    private float pitch;
    public GameObject c;

    void Start ()
    {
        rB = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {
        // movement
        /*float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(Horizontal, 0.0f, Vertical);

        rB.AddForce(move * movementSpeed);*/

        fAndB = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        rAndL = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(rAndL, 0, fAndB);

        // jumping
            if (onGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rB.velocity = new Vector3(0f, jumpHeight, 0f);
                onGround = false;
            }
        }

        // camera
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        //c.transform.eulerAngles = new Vector3(pitch, 0.0f, 0.0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }
}
