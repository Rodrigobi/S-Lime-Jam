using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public Transform gridTransform; // Reference to the grid's Transform component
    public Transform leverTransform; // Reference to the lever's Transform component
    public float moveSpeed = 2f; // Speed of grid movement
    public float minYPosition = 0f; // Minimum Y position of the grid
    public float maxYPosition = 5f; // Maximum Y position of the grid

    private bool isLeverActivated = false; // Track the lever's state

    private void Update()
    {
        // Check for lever activation input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleLever();
        }

        // Move the grid based on the lever's state
        float targetYPosition = isLeverActivated ? maxYPosition : minYPosition;
        float newYPosition = Mathf.MoveTowards(gridTransform.position.y, targetYPosition, moveSpeed * Time.deltaTime);
        gridTransform.position = new Vector3(gridTransform.position.x, newYPosition, gridTransform.position.z);
    }

    private void ToggleLever()
    {
        isLeverActivated = !isLeverActivated;
    }
}
