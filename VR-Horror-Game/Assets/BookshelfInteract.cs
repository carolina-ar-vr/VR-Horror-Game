using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class BookshelfInteract : MonoBehaviour
{
    public float interactRange = 3f;
    private Transform player;
    private bool playerInRange = false;

    [Header("Jumpscare")]
    public GameObject jumpscareImage;
    public AudioSource jumpscareSound;
    public float jumpscareDuration = 2f;
    private bool hasJumpscared = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        jumpscareImage.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        playerInRange = distance <= interactRange;

        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame && !hasJumpscared)
        {
            Interact();
        }
    }

    void Interact()
    {
        hasJumpscared = true;
        StartCoroutine(Jumpscare());
    }

    IEnumerator Jumpscare()
    {
        // Show image and play sound
        jumpscareImage.SetActive(true);
        jumpscareSound.Play();

        // Wait then hide it
        yield return new WaitForSeconds(jumpscareDuration);
        jumpscareImage.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}