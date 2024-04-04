using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float climbSpeed = 3f; // Speed at which the player climbs the ladder
    public float distanceToLadder = 1.5f; // Distance from which the player can start climbing the ladder

    private bool isClimbing = false; // Flag to track if the player is currently climbing
    private Rigidbody2D rb; // Reference to the player's Rigidbody2D component

    void Start()
    {
        // Get the player's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is close to the ladder and not climbing
        if (Input.GetKeyDown(KeyCode.W) && !isClimbing)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, distanceToLadder);
            if (hit.collider != null && hit.collider.CompareTag("Ladder"))
            {
                StartClimbing();
            }
        }

        // Check if the player is climbing
        if (isClimbing)
        {
            // Handle player input for climbing
            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
        }
    }

    void StartClimbing()
    {
        isClimbing = true;
        rb.gravityScale = 0f; // Disable gravity while climbing
        rb.velocity = Vector2.zero; // Reset velocity
    }

    void StopClimbing()
    {
        isClimbing = false;
        rb.gravityScale = 1f; // Restore gravity after climbing
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            StopClimbing();
        }
    }
}
