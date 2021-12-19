using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int inventorySize = 10;
    
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;


    public bool AddItem(Item item)
    {
        if (items.Count <= inventorySize)
        {
            items.Add(item);

            if (OnItemChangedCallback != null)
            {
                OnItemChangedCallback.Invoke();
            }

            return true;
        }
        else
        {
            print("Not enough space in inventory!");
            return false;
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);


        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
        
        
    }
}
