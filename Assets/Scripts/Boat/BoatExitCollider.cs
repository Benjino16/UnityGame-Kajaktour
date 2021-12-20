using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatExitCollider : MonoBehaviour
{
    private List<Collider2D> colliders = new List<Collider2D>();
    public bool exitPoint;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliders.Add(collision);
        exitPoint = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliders.Remove(collision);
        if (colliders.Count == 0)
        {
            exitPoint = false;
        }
    }
}
