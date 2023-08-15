using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Adjust this to control the speed of the slime

    public Animator slimeAnimator; // Reference to the animator component

    private Rigidbody2D rb;
    private bool isFlipped = false;
    private bool isMoving = false; // Added variable to track movement state

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal input (A/D or Left/Right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the new position of the slime
        Vector2 newPosition = rb.position + new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0);

        // Move the slime to the new position
        rb.MovePosition(newPosition);

        // Check if the player presses the "C" key to change gravity
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFlipped = !isFlipped;
            rb.gravityScale *= -1; // Invert gravity

            // Reset vertical velocity if changing gravity to prevent unnatural movement
            rb.velocity = new Vector2(rb.velocity.x, 0);

            // Rotate the slime to match the new gravity direction
            transform.Rotate(new Vector3(0, 0, 180));
        }

        // Update the animator parameter "isMoving"
        isMoving = Mathf.Abs(horizontalInput) > 0;
        slimeAnimator.SetBool("isMoving", isMoving);
    }
}
