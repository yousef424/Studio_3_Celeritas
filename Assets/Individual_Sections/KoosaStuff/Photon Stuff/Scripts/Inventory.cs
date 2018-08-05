using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int slots = 3;
    public List<Item> items = new List<Item>();

    public void AddItem(Item itemToAdd)
    {
        if(!items.Contains(itemToAdd) && items.Count<=slots-1)
        {
            items.Add(itemToAdd);
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
            items.Remove(itemToRemove);
    }


}
