using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public Image icon;
    public Button sellButton;
    public Inventory inventory;
    public void Start()
    {
        //inventory = GetComponent<Inventory>();
    }
    
    public void AddItem(Item itemToAdd)
    {
        item = itemToAdd;
        icon.sprite = item.icon;
        icon.enabled = true;
        sellButton.interactable = true;

        
    }
    public void EmptySlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        sellButton.interactable = false;
    }
    public void SellItem()
    {
        inventory.RemoveItem(item);


    }

	
}
