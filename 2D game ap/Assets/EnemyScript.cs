using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed at which the enemy moves towards the player
    public float detectionRange = 5f; // Range at which the enemy detects the player
    public int damageAmount = 10; // Amount of damage inflicted by the enemy

    private Rigidbody2D rb; // Reference to the enemy's Rigidbody2D component
    private bool isChasing = false; // Flag to track if the enemy is currently chasing the player

    void Start()
    {
        // Get the enemy's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is within detection range and the enemy is not already chasing
        if (!isChasing && Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            StartChasing();
        }

        // If the enemy is chasing, move towards the player
        if (isChasing)
        {
            // Calculate direction towards the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Move towards the player
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            // If not chasing, stop moving
            rb.velocity = Vector2.zero;
        }
    }

    void StartChasing()
    {
        isChasing = true;
    }

    // Check for collision with the player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the player's health script
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // If the player's health script is found, apply damage to the player
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
