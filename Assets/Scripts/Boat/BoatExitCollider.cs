using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatExitCollider : MonoBehaviour
{
    private List<Collider2D> colliders = new();
    public bool exitPoint;
    private readonly Quaternion normalRotation = new() { z = 90 };
    
    private void Update()
    {
        transform.rotation = normalRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliders.Add(collision);
        exitPoint = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliders.Remove(collision);
        if (colliders.Count == 0)
        {
            exitPoint = true;
        }
    }
}
