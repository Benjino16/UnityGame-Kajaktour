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
    [SerializeField] GameManager gameManager;

    InventorySlot[] slots;


    public delegate void OnInventoryOpen();
    public OnInventoryOpen OnInventoryOpenCallback;

    public delegate void OnInventoryClose();
    public OnInventoryClose OnInventoryCloseCallback;

    private void Awake()
    {
        inventory.OnItemChangedCallback += UpdateUI;                        //Subscribe the "UpdateUI" function to the OnItemChangedCallback Event/Delegate!
        slots = invSlotsParent.GetComponentsInChildren<InventorySlot>();    //Sets the slots array to the InvSlot-Button objects in the scene
        UpdateUI();                                                         //Update UI to start the the start Items will be shown in the Inventory
    }


    private void Update()
    {

        //Opens/Closes the inventory if the player press the "Inventory" button
        //LATER THE PLAYER CAN ONLY OPEN THE INVENTORY IN THE NEAR OF THE BOAT
        //(THE INVENTORY IS THE INVENTORY OF THE BOAT)


        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            gameManager.menuOpen = inventoryUI.activeSelf;
            playerMovement.EnableMovementInput(!inventoryUI.activeSelf);

            if(inventoryUI.activeSelf)
            {
                OnInventoryOpenCallback.Invoke();
            }
            else
            {
                OnInventoryCloseCallback.Invoke();
            }

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
