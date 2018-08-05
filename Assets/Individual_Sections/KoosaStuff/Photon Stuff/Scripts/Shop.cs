using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public bool shop;

    public void Update()
    {
        if (shop)
            OpenShop();
        if (!shop)
            CloseShop();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCollider"))
        {
            OpenShop();
            Debug.Log("i hit");
            shop = true;
        }
   }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCollider"))
        {
            CloseShop();
            Debug.Log("kill");
            shop = false;
        }
    }

    void OpenShop()
    {
        shopPanel.SetActive(true);
        //Time.timeScale = 0;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        //Time.timeScale = 1;
    }
}

