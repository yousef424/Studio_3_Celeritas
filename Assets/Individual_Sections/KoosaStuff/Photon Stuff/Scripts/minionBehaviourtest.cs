using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionBehaviourtest : MonoBehaviour
{
    #region Public Variables
    [SerializeField]
    public GameObject[] waypoints;
    public float speed;
    #endregion

    #region Private Variables
    [SerializeField]
    private int target;
    private bool isReverse;
    #endregion

    #region Unity Functions

    // Use this for initialization
    void Start()
    {
        target = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].transform.position, speed);
        Quaternion.LookRotation(waypoints[target].transform.position);
        if (Vector3.Distance(transform.position, waypoints[target].transform.position) < 1)
            target++;
        /*
        if (target == waypoints.Length && !isReverse)
        {
            isReverse = true;
            target -= 1;
        }
        if (Vector3.Distance(transform.position, waypoints[target].transform.position) < 1 && isReverse)
            target--;
        if (Vector3.Distance(transform.position, waypoints[0].transform.position) < 1 && isReverse)
        {
            target = 0;
            isReverse = false;
        }
        */
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="base1")
            gameObject.SetActive(false);
        target = 0;
    }

}
#endregion

