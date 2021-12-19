using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KajakEnterLeave : Interactable
{
    [SerializeField] private GameObject player;

    private SpriteRenderer playerSpriteRenderer;
    private PlayerMovement playerMovement;
    private PlayerStats playerStats;
    private Rigidbody2D playerRigendbody;

    private void Awake()
    {
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerStats = player.GetComponent<PlayerStats>();
        playerRigendbody = player.GetComponent<Rigidbody2D>();
    }


    public override void Update()
    {
        if (Input.GetButtonDown("Action1") && inInteractionRange && !playerStats.inBoat)
        {
            Interact();
        }
        else if (Input.GetButtonDown("Action1") && playerStats.inBoat)
        {
            KajakExit();
            print("Player Exit Kajak");
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
        playerStats.inBoat = true;
        playerMovement.movementActive = false;
        player.transform.parent = gameObject.transform;
        playerRigendbody.simulated = false;
    }

    public void KajakExit()
    {
        playerSpriteRenderer.enabled = true;
        playerStats.inBoat = false;
        playerMovement.movementActive = true;
        player.transform.parent = null;
        playerRigendbody.simulated = true;
    }
}
