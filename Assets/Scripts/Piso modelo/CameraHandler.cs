using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform playerTransform;   // Reference to the player's transform
    public Vector3 offset;              // Offset from the player's position

    void LateUpdate()
    {
        // Set the camera's position to the player's position plus the offset
        transform.position = playerTransform.position + offset;

        // Rotate the camera to always look at the player
        transform.LookAt(playerTransform);
    }
}
