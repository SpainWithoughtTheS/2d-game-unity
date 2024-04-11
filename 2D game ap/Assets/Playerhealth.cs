using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public Sprite[] healthSprites; // Array of sprites representing different health levels

    void Start()
    {
        maxHealth = health;
        UpdateHealthBarSprite(); // Update health bar sprite at start
    }

    void Update()
    {
        // Update health bar fill amount
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        // Update health bar sprite based on current health
        UpdateHealthBarSprite();
    }

    void UpdateHealthBarSprite()
    {
        // Calculate the percentage of health remaining
        float healthPercentage = health / maxHealth;

        // Calculate the index of the sprite to use based on health percentage
        int spriteIndex = Mathf.RoundToInt(healthPercentage * (healthSprites.Length - 1));

        // Set the health bar sprite to the appropriate sprite
        if (spriteIndex >= 0 && spriteIndex < healthSprites.Length)
        {
            healthBar.sprite = healthSprites[spriteIndex];
        }
        else
        {
            Debug.LogWarning("Sprite index out of range.");
        }
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
