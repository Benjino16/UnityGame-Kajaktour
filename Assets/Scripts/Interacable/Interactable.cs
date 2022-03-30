using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool inInteractionRange;
    public virtual void Update()
    {
        if(Input.GetButtonDown("Interact") && inInteractionRange) 
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("InteractionRange"))
        {
            inInteractionRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("InteractionRange"))
        {
            inInteractionRange = false;
        }
    }

    public virtual void Interact()
    {
        print("Player interacting with " + gameObject.name);

    }
}
