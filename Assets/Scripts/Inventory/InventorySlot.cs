using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Hotbar hotbar;
    [SerializeField] Inventory inventory;
    public Image icon;
    Item item;
    

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = newItem.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }


    public void inventoryItemClick()
    {
        if(item != null)
        {
            if(hotbar.AddItem(item))
            {
                inventory.RemoveItem(item);
            }
        }
    }
}