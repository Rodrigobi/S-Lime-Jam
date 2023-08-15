using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int maxHealthIncrease = 10; // Amount to increase the player's max health

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player's tag is "Player"
        {
            // Check if the player can pick up the health
            SlimeHealth slimeHealth = other.GetComponent<SlimeHealth>();
            if (slimeHealth != null)
            {
                // Increase the player's max health
                slimeHealth.IncreaseMaxHealth(maxHealthIncrease);

                // Heal the player by 10 points (if not exceeding max health)
                slimeHealth.Heal(10);

                // Destroy the pickup object only when the player collides
                Destroy(gameObject);
            }
        }
    }
}
