using UnityEngine;

public class LightFollowPlayer : MonoBehaviour
{
    public Transform player; // Assign the player's transform in the Inspector

    private UnityEngine.Rendering.Universal.Light2D light2D;

    private void Awake()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    private void Update()
    {
        if (player != null)
        {
            // Update the light's position to match the player's position
            Vector3 playerPosition = player.position;
            playerPosition.z = transform.position.z; // Maintain the light's original z position
            transform.position = playerPosition;
        }
    }
}
