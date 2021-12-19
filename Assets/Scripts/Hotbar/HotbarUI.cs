using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] Hotbar hotbar;

    [SerializeField] Image activeItemIcon;
    [SerializeField] Image secondItemIcon;
    [SerializeField] Image thirdItemIcon;


    private void Start()
    {
        UpdateHotbar();
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
