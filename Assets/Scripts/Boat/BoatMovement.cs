using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    [Header("Boat Settings:")]
    [SerializeField] private float boatSpeed = 15f;
    [SerializeField] private float turnSpeed = 50f;
    [SerializeField] private float keepSpeed = 0.02f;
    [SerializeField] private float liniearDrag = 1f;

    [Header("Other Components:")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerStats playerStats;


    private Vector2 boatMovement;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region Get Input
        boatMovement.x = Input.GetAxisRaw("Horizontal");
        boatMovement.y = Input.GetAxisRaw("Vertical");
        #endregion

        //Calculate and sets the liniearDrag of the rb componet for the boat, depending on the rotation
        rb.drag =  liniearDrag * (-Mathf.Abs((Vector2.Angle(rb.velocity, transform.up) - 90) / 90) + 1);
    }

    private void FixedUpdate()
    {
        if (playerStats.inBoat)
        {


            rb.AddTorque(turnSpeed * boatMovement.x * Time.fixedDeltaTime * -1);
            rb.AddForce(transform.up * boatSpeed * Time.fixedDeltaTime * boatMovement.y);


            // Adds the force to the boat, that its not instantly loose his speed
            rb.AddForce(Vector2.Reflect(rb.velocity * -1, transform.up) * keepSpeed);
        }
    }
}