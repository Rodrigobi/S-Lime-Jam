using UnityEngine;

public class SlimeDamage : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to apply
    public float forceAmount = 100f; // Amount of force to apply

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Assuming the slime's tag is "Player"
        {
            // Apply damage to the slime
            SlimeHealth slimeHealth = collision.gameObject.GetComponent<SlimeHealth>();
            if (slimeHealth != null)
            {
                slimeHealth.TakeDamage(damageAmount);
            }

            // Apply force to the slime
            Rigidbody2D slimeRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (slimeRigidbody != null)
            {
                Vector2 forceDirection = (collision.transform.position - transform.position).normalized;
                slimeRigidbody.AddForce(forceDirection * forceAmount, ForceMode2D.Impulse);
            }
        }
    }
}
