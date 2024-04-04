using UnityEngine;
using UnityEngine.UI; // Add this line to include the Image type

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
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
}
