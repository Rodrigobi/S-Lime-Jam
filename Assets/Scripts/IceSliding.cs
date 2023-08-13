using UnityEngine;

public class IceSliding : MonoBehaviour
{
    public float slideSpeed = 10f; // Speed of sliding
    public float turnDelay = 0.5f; // Delay before turning around
    private float turnDelayTimer = 0f; // Timer to track turning delay

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Update the turning delay timer
        turnDelayTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Apply sliding force when there's horizontal input and not within the turn delay
        if (Mathf.Abs(horizontalInput) > 0.1f && turnDelayTimer <= 0f)
        {
            // Apply force for sliding
            rb.AddForce(Vector2.right * horizontalInput * slideSpeed, ForceMode2D.Impulse);

            // Set the turning delay timer
            turnDelayTimer = turnDelay;
        }
    }
}
