using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventory : MonoBehaviour
{
    #region Public Variables
    public Item item;
    public Item item2;
    public Inventory inventory;
    #endregion

    #region Unity Callbacks
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
           inventory.AddItem(item);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            inventory.AddItem(item2);
        }

    }
}
#endregion
