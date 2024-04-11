using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth; // Reference to the PlayerHealth script
    public float damage; // Amount of damage to apply

    void Start()
    {
        // Initialize the pHealth reference by finding the PlayerHealth script on the player GameObject
        pHealth = FindObjectOfType<PlayerHealth>();

        // If the pHealth reference is still null, log a warning message
        if (pHealth == null)
        {
            Debug.LogWarning("PlayerHealth reference is null. Make sure the PlayerHealth script is attached to the player GameObject.");
        }
    }

    void Update()
    {
        // You can add update logic here if needed
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if the pHealth reference is valid
            if (pHealth != null)
            {
                // Apply damage to the player
                pHealth.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("PlayerHealth reference is null. Make sure to assign it in the Inspector or initialize it in Start.");
            }
        }
    }
}
