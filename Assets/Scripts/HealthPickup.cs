using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int maxHealthIncrease = 10; // Amount to increase the player's max health

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player's tag is "Player"
        {
            // Check if the player can pick up the health (based on cooldown)
            SlimeHealth slimeHealth = other.GetComponent<SlimeHealth>();
            if (slimeHealth != null && slimeHealth.CanPickup())
            {
                slimeHealth.IncreaseMaxHealth(maxHealthIncrease);

                // Start the cooldown for picking up health
                slimeHealth.StartCooldown();

                // Destroy the pickup object
                Destroy(gameObject);
            }
        }
    }
}
