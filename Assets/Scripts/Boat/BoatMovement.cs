using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoatMovement : MonoBehaviour
{

    [SerializeField] private float energyDrain = 1f;

    [Header("Movement Settings:")]
    [SerializeField] private float boatSpeed = 15f;
    [SerializeField] private float turnSpeed = 50f;
    [SerializeField] private float keepSpeed = 0.02f;

    [Space]
    [Header("Drag Settings:")]
    [SerializeField] private float liniearDrag = 1f;
    [SerializeField] private float angularDrag = 3f;
    [SerializeField] private float minAngDrag = 0.5f;

    [Space]
    [Header("Other Components:")]
    [SerializeField] private Rigidbody2D rigedbody;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private InputMaster inputMaster;
    

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
        SetAngularDrag();
        /*The angular drag depending on the boat speed,
            the faster the boat the less angular drag is applied*/
    }

    private void FixedUpdate()
    {
        if (playerStats.inBoat && playerStats.energy >  0)
        {
            //Remove players energy based on the players input
            playerStats.ModifyEnergy(-(boatMovement.sqrMagnitude * energyDrain));

            //Apply boat movement speed based on the input
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



    //Normaly this should change the boat turn rate based on the speed
    //But its not working :)))
    private void SetAngularDrag()
    {
        rigedbody.angularDrag = -rigedbody.velocity.sqrMagnitude + 1;
        if(rigedbody.angularDrag < minAngDrag) { rigedbody.angularDrag = 0.5f; }
    }
}