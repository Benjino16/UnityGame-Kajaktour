using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KajakEnterLeave : Interactable
{
    [SerializeField] GameObject player;
    public bool playerInKajak = false;

    public override void Interact()
    {
        base.Interact();
        print("Player tryes to enter Kajak!");
        KajakEnter();
    }

    public void KajakEnter()
    {
        player.SetActive(false);
    }

    public void KajakExit()
    {
        player.SetActive(true);
    }


}
