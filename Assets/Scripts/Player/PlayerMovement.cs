using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [Header("Movement Settings")]
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float energyDrain = -1;

    [Space] [Header("Interacteble Transform")]
    [SerializeField] Transform interacebleArea;
    [SerializeField] float interactebleRangeTransform = 1f;


    [Space]
    [Header("Other needed Components")]
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] Animator animator;

    [System.NonSerialized]

    public bool movementActive = true;

    Vector2 movement;
    Rigidbody2D rigedbody;
    Vector2 lastPosition;


    private void Awake()
    {
        rigedbody = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
    }
    void Update()
    {
        if (movementActive)
        {

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            RunAnimation();

            TransformInteraceble();

        }
    }

    private void FixedUpdate()
    {
        rigedbody.MovePosition(rigedbody.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
        if(movement.sqrMagnitude != 0)
        {
            playerStats.ModifyEnergy(energyDrain);
        }
    }

    private void RunAnimation()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        if (movement.x != 0f)
        {
            lastPosition = new Vector2(movement.x, 0);
            UpdateAnimator();

        } else if (movement.y != 0f){
            lastPosition = new Vector2(0, movement.y);
            UpdateAnimator();
        }
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("LastHorizontal", movement.x);
        animator.SetFloat("LastVertical", movement.y);
    }

    private void TransformInteraceble()
    {
        interacebleArea.transform.position = lastPosition * interactebleRangeTransform + rigedbody.position; //MUSS NOCHMAL ÜBERARBEITET WERDEN (VARIABLEN ZUM ANPASSEN ERSTELLEN)
    }


    public void ActivateMovement(bool status)
    {
        movementActive = status;
        if (!status)
        {
            movement.Set(0, 0);
            animator.SetFloat("Speed", 0);
        }
    }
}
