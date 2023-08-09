using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float stickyForce = 10f;
    public float gravityChangeForce = 50f;
    public float ceilingRaycastDistance = 1f; // Adjust this distance based on your level design
    public float maxCeilingHeight = 2f; // Adjust this value based on the maximum allowable ceiling height

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGravityChanged = false; // Track if gravity is changed.

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Read player input for movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Check for gravity change input
        if (Input.GetKeyDown(KeyCode.C) && CanChangeGravity())
        {
            ChangeGravityDirection();
        }
    }

    private bool CanChangeGravity()
    {
        // Check if there is a ceiling above the slime using a raycast
        RaycastHit2D ceilingHit = Physics2D.Raycast(transform.position, Vector2.up, ceilingRaycastDistance);
        
        // Additional check: Make sure the ceiling height is within the allowable range
        return ceilingHit.collider != null && ceilingHit.distance <= maxCeilingHeight;
    }

    private void FixedUpdate()
    {
        // Apply movement based on input
        Vector2 moveForce = moveInput * moveSpeed;
        rb.AddForce(moveForce);

        // Apply sticky force to the surface to prevent falling
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.5f);
        if (hit.collider != null)
        {
            rb.AddForce(-transform.up * stickyForce);
        }
    }

    private void ChangeGravityDirection()
    {
        // Toggle gravity direction
        isGravityChanged = !isGravityChanged;

        // Apply a force to simulate gravity change
        Vector2 gravityDirection = isGravityChanged ? Vector2.up : Vector2.down;
        rb.AddForce(gravityDirection * gravityChangeForce, ForceMode2D.Impulse);

        // Rotate the slime sprite to match the new gravity direction
        float angle = isGravityChanged ? 180f : 0f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
