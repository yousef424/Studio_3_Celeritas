using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public Transform itemParent;
    public Inventory inventory;
   public InventorySlot[] inventorySlot;

	// Use this for initialization
	void Start ()
    {
        inventory = GetComponent<Inventory>();
        inventorySlot = itemParent.GetComponentsInChildren<InventorySlot>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        for(int i =0; i<inventorySlot.Length; i++)
        {
            if (i < inventory.items.Count)
                inventorySlot[i].AddItem(inventory.items[i]);

            else
                inventorySlot[i].EmptySlot();
        }
		
	}
}
