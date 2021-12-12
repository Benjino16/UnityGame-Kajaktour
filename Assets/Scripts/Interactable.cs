using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool inInteractionRange;
    private void Update()
    {
        if(Input.GetButtonDown("Action1") && inInteractionRange) {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "InteractionRange")
        {
            inInteractionRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "InteractionRange")
        {
            inInteractionRange = false;
        }
    }

    public virtual void Interact()
    {
        print("Interacting...");
    }
}
