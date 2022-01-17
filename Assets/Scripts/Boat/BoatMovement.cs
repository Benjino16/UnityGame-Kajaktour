using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    [Header("Boat Settings:")]
    [SerializeField] private float boatSpeed = 15f;
    [SerializeField] private float turnSpeed = 50f;
    [SerializeField] private float keepSpeed = 0.02f;
    [Header("Drag Settings:")]
    [SerializeField] private float liniearDrag = 1f;
    [SerializeField] private float angularDrag = 3f;
    [SerializeField] private float minAngDrag = 0.5f;

    [Space]
    [Header("Other Components:")]
    [SerializeField] private Rigidbody2D rigedbody;
    [SerializeField] private PlayerStats playerStats;
    

    private Vector2 boatMovement;


    private void Awake()
    {
        rigedbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region Get Input
        boatMovement.x = Input.GetAxisRaw("Horizontal");
        boatMovement.y = Input.GetAxisRaw("Vertical");
        #endregion

        SetLinearDrag();
        //SetAngularDrag();
    }

    private void FixedUpdate()
    {
        if (playerStats.inBoat)
        {


            rigedbody.AddTorque(turnSpeed * boatMovement.x * Time.fixedDeltaTime * -1);
            rigedbody.AddForce(transform.up * boatSpeed * Time.fixedDeltaTime * boatMovement.y);


            // Adds the force to the boat, that its not instantly loose his speed
            rigedbody.AddForce(Vector2.Reflect(rigedbody.velocity * -1, transform.up) * keepSpeed);
        }
    }

    private void SetLinearDrag()
    {
        //Calculate and sets the liniearDrag of the rb componet for the boat, depending on the rotation
        rigedbody.drag = liniearDrag * (-Mathf.Abs((Vector2.Angle(rigedbody.velocity, transform.up) - 90) / 90) + 1);
    }

    private void SetAngularDrag()
    {
        rigedbody.angularDrag = 100 - (angularDrag * rigedbody.velocity.sqrMagnitude);
        if(rigedbody.angularDrag < minAngDrag) { rigedbody.angularDrag = 0.5f; }
    }
}