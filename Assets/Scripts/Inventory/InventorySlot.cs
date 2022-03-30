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
    
    /// <summary>
    /// Adds an item to the specific inventory slot
    /// </summary>
    /// <param name="newItem">The item thats </param>
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = newItem.icon;
        icon.enabled = true;
        button.enabled = true;
    }

    /// <summary>
    /// Clears an inventory slot and deletes the item
    /// </summary>
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        button.enabled = false;
    }


    public void InventoryClickItem()
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