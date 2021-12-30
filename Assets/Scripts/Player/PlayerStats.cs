using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public bool inBoat;

    public float energy;


    /// <summary>
    /// Modifys the players energy.
    /// </summary>
    public void ModifyEnergy(float number)
    {
        energy += number;
        if(energy > 100)
        {
            energy = 100;
        }
        if (energy < 0)
        {
            energy = 0;
            //GAME OVER
        }
    }

}
