using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the move speed as needed
    public float gravityChangeForce = 50f; // Adjust the gravity change force as needed

    private Rigidbody2D rb;
    private bool isGravityChanged = false;
    private bool isMoving = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Read player input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Determine if the slime is moving
        isMoving = moveDirection != Vector2.zero;

        // Apply movement force to the rigidbody if moving
        if (isMoving)
        {
            Vector2 moveForce = moveDirection * moveSpeed;
            rb.AddForce(moveForce);
        }

        // Check for gravity change input
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeGravityDirection();
        }
    }

    private void ChangeGravityDirection()
    {
        isGravityChanged = !isGravityChanged;

        if (isGravityChanged)
        {
            rb.gravityScale = -1f; // Reverse gravity
            // Flip the sprite's Y orientation
            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), 1f); // Flipped orientation
        }
        else
        {
            rb.gravityScale = 1f; // Restore normal gravity
            // Restore the sprite's Y orientation
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), 1f); // Normal orientation
        }

        rb.velocity = Vector2.zero; // Reset velocity to prevent unwanted motion
    }
}
