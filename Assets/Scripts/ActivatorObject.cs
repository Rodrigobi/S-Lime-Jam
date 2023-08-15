using UnityEngine;

public class ActivatorObject : MonoBehaviour
{
    public GridMovement gridMovement; // Reference to the GridMovement script

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player's tag is "Player"
        {
            // Toggle the activation of the GridMovement script
            if (gridMovement != null)
            {
                gridMovement.ToggleActivation();
            }
        }
    }
}
