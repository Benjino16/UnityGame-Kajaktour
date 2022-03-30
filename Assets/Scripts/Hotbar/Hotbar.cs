using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hotbar : MonoBehaviour
{
    [Header("Hotbar Items:")]
    public Item activeItem;
    public Item secondItem;
    public Item thirdItem;

    [Space]
    [Header("Need Componets:")]
    [SerializeField] HotbarUI hotbarUI;
    [SerializeField] Inventory inventory;
    [SerializeField] PlayerStats playerStats;

    private Item temporaryItem;

    public void UseItem()
    {
        if(activeItem)
        {
            if (activeItem.Use(playerStats)) { activeItem = null; hotbarUI.UpdateHotbar(); }
        }
    }

    public void SwitchHotbar2()
    {
        temporaryItem = activeItem;
        activeItem = secondItem;
        secondItem = temporaryItem;

        hotbarUI.UpdateHotbar();
    }

    public void SwitchHotbar3()
    {
        temporaryItem = activeItem;
        activeItem = thirdItem;
        thirdItem = temporaryItem;

        hotbarUI.UpdateHotbar();
    }


    #region ButtonFunctions (DO NOT OPEN, CODE IS TERRIBLE)
    public void MainButton()
    {
        if (activeItem)
        {
            if(inventory.AddItem(activeItem)) { activeItem = null; }
            hotbarUI.UpdateHotbar();
        }
    }

    public void SecondButton()
    {
        if (secondItem)
        {
            if (inventory.AddItem(secondItem)) { secondItem = null; }
            hotbarUI.UpdateHotbar();
        }
    }

    public void ThirdButton()
    {
        if (thirdItem)
        {
            if (inventory.AddItem(thirdItem)) { thirdItem = null; }
            hotbarUI.UpdateHotbar();
        }
    }



    #endregion

    public bool AddItem(Item item)
    {
        Debug.Log("Tried to add an item to the hotbar!");
        if (!activeItem)
        {
            activeItem = item;
            hotbarUI.UpdateHotbar();
            return true;
        }
        else if (!secondItem)
        {
            secondItem = item;
            hotbarUI.UpdateHotbar();
            return true;
        }
        else if (!thirdItem)
        {
            thirdItem = item;
            hotbarUI.UpdateHotbar();
            return true;
        }
        hotbarUI.UpdateHotbar();
        return false;
    } 
}
