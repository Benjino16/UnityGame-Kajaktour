using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        print("Picking up Item");
        //If inventorySpace > inventoryMaxSpace

    }
}
