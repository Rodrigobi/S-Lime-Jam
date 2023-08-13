using UnityEngine;

public class SlimeHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the slime
    private int currentHealth; // Current health of the slime

    private int maxHealthIncrease = 0; // Amount to increase max health by
    private float cooldownDuration = 5f; // Cooldown duration in seconds
    private float cooldownTimer = 0f; // Timer to track cooldown

    private void Awake()
    {
        currentHealth = maxHealth; // Initialize health to maxHealth
    }

    private void Update()
    {
        // Update cooldown timer
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0f)
        {
            cooldownTimer = 0f;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce health by damageAmount

        // Check if the slime's health has reached zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealthIncrease += amount; // Increase the player's max health
        maxHealth += amount; // Also increase max health by the same amount
        
        // Increase the slime's scale by 0.01
        Vector3 newScale = transform.localScale + new Vector3(0.5f, 0.5f, 0f);
        transform.localScale = newScale;
    }

    public bool CanPickup()
    {
        return cooldownTimer <= 0f;
    }

    public void StartCooldown()
    {
        cooldownTimer = cooldownDuration;
    }
    
    private void Die()
    {
        // Implement any death behavior here (e.g., play death animation, destroy object, etc.)
        Destroy(gameObject); // For example, destroy the slime GameObject
    }
}
