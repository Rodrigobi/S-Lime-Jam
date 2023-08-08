using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickySlimeController : MonoBehaviour
{
    public float stickForce = 10f; // The force applied to stick the slime to tiles

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Disable gravity for sticking behavior
        rb.constraints = RigidbodyConstraints2D.FreezePositionY; // Freeze vertical position
    }

    private void Update()
    {
        // Apply sticking force in the opposite direction of the slime's current orientation
        Vector2 stickForceVector = -transform.up * stickForce;
        rb.AddForce(stickForceVector, ForceMode2D.Force);
    }
}
