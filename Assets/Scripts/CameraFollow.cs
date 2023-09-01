using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform slimePrefab; // Reference to the slime prefab
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public Vector3 offset; // Offset between the camera and the slimes

    private Transform slime1; // Reference to the first slime transform
    private Transform slime2; // Reference to the second slime transform

    private void LateUpdate()
    {
        if (slime1 != null && slime1.gameObject.activeSelf &&
            slime2 != null && slime2.gameObject.activeSelf)
        {
            Vector3 middlePoint = (slime1.position + slime2.position) / 2f;
            Vector3 desiredPosition = middlePoint + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }

    // Call this function whenever a slime divides to update the references
    public void UpdateSlimeReferences(Transform newSlime)
    {
        slime2 = slime1;
        slime1 = newSlime;
    }
}
