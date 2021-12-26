using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] Hotbar hotbar;

    [SerializeField] InventoryUI inventoryUI;

    [SerializeField] Image activeItemIcon;
    [SerializeField] Image secondItemIcon;
    [SerializeField] Image thirdItemIcon;

    [SerializeField] Button[] buttons;

    private void Awake()
    {
        inventoryUI.OnInventoryOpenCallback += ActivateButtons;
        inventoryUI.OnInventoryCloseCallback += DeactivateButtons;
    }



    private void Start()
    {
        UpdateHotbar();
    }


    private void ActivateButtons()
    {
        foreach (Button button in buttons)
        {
            button.enabled = true;
        }
    }

    private void DeactivateButtons()
    {
        foreach (Button button in buttons)
        {
            button.enabled = false;
        }
    }



    public void UpdateHotbar()
    {
        print("Updating hotbarUI!");
        if(hotbar.activeItem)
        {
            activeItemIcon.sprite = hotbar.activeItem.icon;
            activeItemIcon.enabled = true;
        }
        else
        {
            activeItemIcon.sprite = null;
            activeItemIcon.enabled = false;
        }


        if (hotbar.secondItem)
        {
            secondItemIcon.sprite = hotbar.secondItem.icon;
            secondItemIcon.enabled = true;
        }
        else
        {
            secondItemIcon.sprite = null;
            secondItemIcon.enabled = false;
        }


        if (hotbar.thirdItem)
        {
            thirdItemIcon.sprite = hotbar.thirdItem.icon;
            thirdItemIcon.enabled = true;
        }
        else
        {
            thirdItemIcon.sprite = null;
            thirdItemIcon.enabled = false;
        }

    }
}
