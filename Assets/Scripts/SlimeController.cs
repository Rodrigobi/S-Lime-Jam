using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed = 3f; // Movement speed
    public LayerMask groundLayer; // Layer where movement is allowed

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check for collisions with objects on the groundLayer before applying movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 targetVelocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);

        if (CanMoveToTargetPosition(targetVelocity))
        {
            rb.velocity = targetVelocity;
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop movement if not allowed
        }
    }

    private bool CanMoveToTargetPosition(Vector2 targetVelocity)
    {
        Vector2 targetPosition = rb.position + targetVelocity * Time.deltaTime;
        
        RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.down, 0.1f, groundLayer);
        
        return hit.collider != null;
    }
}
