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
        activeItemIcon.sprite = hotbar.activeItem.icon;
        secondItemIcon.sprite = hotbar.secondItem.icon;
        thirdItemIcon.sprite = hotbar.thirdItem.icon;
    }
}
