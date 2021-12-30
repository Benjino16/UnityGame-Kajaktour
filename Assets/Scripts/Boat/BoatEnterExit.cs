using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatEnterExit : Interactable
{
    [SerializeField] private GameObject player;


    [SerializeField] private BoatExitCollider leftExitCheck;
    [SerializeField] private BoatExitCollider rightExitCheck;

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
        if (Input.GetButtonDown("Interact") && inInteractionRange && !playerStats.inBoat)
        {
            Interact();
        }
        else if (Input.GetButtonDown("Interact") && playerStats.inBoat)
        {
            if (BoatExit())
            {
                print("Player exit the boat!");
            }
            else
            {
                print("Player tryed to exit the boat but no ground was nearby!");
            }
        }
    }

    public override void Interact()
    {
        base.Interact();
        BoatEnter();
    }

    public void BoatEnter()
    {
        print("Player enter boat!");

        playerSpriteRenderer.enabled = false;
        playerStats.inBoat = true;
        playerMovement.movementActive = false;
        player.transform.parent = gameObject.transform;
        playerRigendbody.simulated = false;
    }

    public bool BoatExit()
    {
        //Checks if the Player CAN NOT exit the boat (if ground is NOT nearby)
        if (!leftExitCheck.exitPoint && !rightExitCheck.exitPoint)
        {
            return false;
        }


        playerSpriteRenderer.enabled = true;
        playerStats.inBoat = false;
        playerMovement.movementActive = true;
        player.transform.parent = null;
        playerRigendbody.simulated = true;

        //Resets the rotation of the player (Its changed while the player is a child of the boat)
        player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (leftExitCheck.exitPoint)
        {
            player.transform.position = leftExitCheck.gameObject.transform.position;
        }
        else if (rightExitCheck.exitPoint)
        {
            player.transform.position = rightExitCheck.gameObject.transform.position;
        }

        return true;
    }
}
