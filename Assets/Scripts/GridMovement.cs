using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of grid movement
    public float minYPosition = 0f; // Minimum Y position of the grid
    public float maxYPosition = 5f; // Maximum Y position of the grid

    private bool isActivated = false; // Track whether the grid can move

    private void Update()
    {
        // Move the grid based on the activation state
        if (isActivated)
        {
            float targetYPosition = maxYPosition;
            float newYPosition = Mathf.MoveTowards(transform.position.y, targetYPosition, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        }
        else
        {
            float targetYPosition = minYPosition;
            float newYPosition = Mathf.MoveTowards(transform.position.y, targetYPosition, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ActivatorObject")) // Change "ActivatorObject" to the appropriate tag
        {
            ToggleActivation();
        }
    }

    public void ToggleActivation()
    {
        isActivated = !isActivated;

        // TODO: You can also add more behavior here, like playing animations or sounds.
    }
}
