using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KajakEnterLeave : Interactable
{
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    public bool playerInKajak = false;


    public override void Update()
    {
        if (Input.GetButtonDown("Action1") && inInteractionRange)
        {
            Interact();
        }
        else if (Input.GetButtonDown("Action1") && playerInKajak)
        {
            KajakExit();
            print("BRXXIIIIIIIIIIIT");
        }
    }

    public override void Interact()
    {
        base.Interact();
        print("Player tryes to enter Kajak!");
        KajakEnter();
    }

    public void KajakEnter()
    {
        playerSpriteRenderer.enabled = false;
        playerInKajak = true;
    }

    public void KajakExit()
    {
        playerSpriteRenderer.enabled = true;
        playerInKajak = false;
    }


}
