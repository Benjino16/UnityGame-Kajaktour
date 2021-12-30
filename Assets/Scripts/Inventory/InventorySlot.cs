using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Hotbar hotbar;
    [SerializeField] Inventory inventory;
    [SerializeField] Image icon;
    [SerializeField] Button button;

    Item item;
    

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = newItem.icon;
        icon.enabled = true;
        button.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        button.enabled = false;
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