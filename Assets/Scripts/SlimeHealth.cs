using UnityEngine;
using UnityEngine.UI;
public class SlimeHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the slime
    private int currentHealth; // Current health of the slime
    public Slider healthSlider; // Reference to the UI Slider element
    public Text healthText;

    private int maxHealthIncrease = 0; // Amount to increase max health by
    private float cooldownDuration = 5f; // Cooldown duration in seconds
    private float cooldownTimer = 0f; // Timer to track cooldown

    private void Awake()
    {
        currentHealth = maxHealth; // Initialize health to maxHealth
        UpdateHealthUI(); // Update the UI text initially
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

        UpdateHealthUI(); // Update the UI text after taking damage
    }

    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        UpdateHealthUI(); // Update the UI text after healing
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealthIncrease += amount; // Increase the player's max health
        maxHealth += amount; // Also increase max health by the same amount
        
        // Increase the slime's scale by 0.01
        Vector3 newScale = transform.localScale + new Vector3(0.01f, 0.01f, 0f);
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

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString(); // Update the UI text
        }

        if (healthSlider != null)
        {
            // Calculate the ratio of current health to maximum health
            float healthRatio = (float)currentHealth / maxHealth;

            // Update the Slider value based on the health ratio
            healthSlider.value = healthRatio;
        }
    }
}

