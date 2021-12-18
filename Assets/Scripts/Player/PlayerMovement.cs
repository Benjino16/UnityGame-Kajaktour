using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public bool canMove = true;


    [SerializeField] float movementSpeed = 10;
    [SerializeField] Animator animator;

    [Header("Interacteble Transform")]
    [SerializeField] Transform interacebleArea;
    [SerializeField] float interactebleRangeTransform = 1f;


    Vector2 movement;
    Rigidbody2D rigedbody;
    Vector2 lastPosition;

    private void Awake()
    {
        rigedbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (canMove)
        {

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            RunAnimation();

            TransformInteraceble();

        } else
        {
            movement.Set(0f, 0f);
        }
    }

    private void FixedUpdate()
    {
        rigedbody.MovePosition(rigedbody.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
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

}
