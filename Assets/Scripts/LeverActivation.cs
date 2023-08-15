using UnityEngine;

public class LeverActivation : MonoBehaviour
{
    public GridMovement gridMovement; // Reference to the GridMovement script

    private bool isLeverActivated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player's tag is "Player"
        {
            ActivateLever();
        }
    }

    private void ActivateLever()
    {
        isLeverActivated = true;

        // Disable the lever's collider and renderer
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        // Toggle the activation of the GridMovement script
        if (gridMovement != null)
        {
            gridMovement.ToggleActivation();
        }
    }
}
