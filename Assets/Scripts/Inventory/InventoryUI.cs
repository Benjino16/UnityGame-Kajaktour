using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject invSlotsParent;
    [SerializeField] GameObject inventoryUI;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Inventory inventory;
    [SerializeField] Hotbar hotbar;

    InventorySlot[] slots;

    private void Awake()
    {
        inventory.OnItemChangedCallback += UpdateUI;                        //Subscribe the "UpdateUI" function to the OnItemChangedCallback Event/Delegate!
        slots = invSlotsParent.GetComponentsInChildren<InventorySlot>();    //Sets the slots array to the InvSlot-Button objects in the scene
        UpdateUI();                                                         //Update UI to start the the start Items will be shown in the Inventory
    }


    private void Update()
    {

        //Opens/Closes the inventory if the player press the "Inventory" button
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            playerMovement.canMove(!inventoryUI.activeSelf);

        }
    }

    private void UpdateUI()
    {

        //Loops through all the Slot-Buttons and Checks, if the inventory has updated for that Slot
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        } 
        Debug.Log("Updating InventoryUI!");
    }
}
