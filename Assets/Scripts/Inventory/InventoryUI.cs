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
        inventory.OnItemChangedCallback += UpdateUI;
        slots = invSlotsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();

    }


    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            playerMovement.canMove(!inventoryUI.activeSelf);

        }
    }

    private void UpdateUI()
    {
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
