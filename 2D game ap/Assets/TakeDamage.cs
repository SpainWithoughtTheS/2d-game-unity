using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth; // Reference to the PlayerHealth script
    public float damage; // Amount of damage to apply

    void Start()
    {
        // You can initialize the pHealth reference here if needed
        // For example:
        // pHealth = FindObjectOfType<PlayerHealth>();
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
