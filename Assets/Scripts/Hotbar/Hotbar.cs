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

    [SerializeField] HotbarUI hotbarUI;
    private Item temporaryItem;


    UnityEvent UpdateUIEvent = new UnityEvent();

    private void Update()
    {
        if(Input.GetButtonDown("Hotbar1"))
        {
            //Main Action
            Debug.Log("Using Main Item");
        }
        if (Input.GetButtonDown("Hotbar2"))
        {
            temporaryItem = activeItem;
            activeItem = secondItem;
            secondItem = temporaryItem;

            hotbarUI.UpdateHotbar();
        }
        if (Input.GetButtonDown("Hotbar3"))
        {
            temporaryItem = activeItem;
            activeItem = thirdItem;
            thirdItem = temporaryItem;

            hotbarUI.UpdateHotbar();
        }
    }

}