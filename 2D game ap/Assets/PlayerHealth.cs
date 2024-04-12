using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public Slider healthSlider; // Reference to the UI Slider component representing the health bar

    void Start()
    {
        maxHealth = health;
        UpdateHealthBar(); // Update health bar at start
    }

    void Update()
    {
        // Update health bar value
        healthSlider.value = Mathf.Clamp01(health / maxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        // Check if the player's health is below zero
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement death behavior here (e.g., respawn, game over, etc.)
        Debug.Log("Player died");
    }

    // Call this method to update the health bar appearance
    void UpdateHealthBar()
    {
        // Update health bar value
        healthSlider.value = Mathf.Clamp01(health / maxHealth);
    }
}
