using UnityEngine;
using UnityEngine.InputSystem;

public class BookshelfInteract : MonoBehaviour
{
    public float interactRange = 3f;
    private Transform player;
    private bool playerInRange = false;

    void Start()
    {
        // Finds your player automatically by tag
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Check distance between player and bookshelf
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= interactRange)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }

        // If in range and E is pressed
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    void Interact()
    {
        // Put whatever you want to happen here
        Debug.Log("You interacted with the bookshelf!");
    }

    // Draws the range as a sphere in the Scene view so you can see it
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}