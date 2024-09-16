using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;  // The player's transform (drag and drop the player here in the Inspector)
    [SerializeField]
    private float smoothTime = 0.3f;  // Time for the camera to reach the player
    [SerializeField]
    private Vector3 offset = new Vector3(0, 2, -10);  // Offset for the camera to follow the player

    private Vector3 velocity = Vector3.zero;  // Required for SmoothDamp to track the current velocity

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        // Target position for the camera (player's position plus the offset)
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera towards the target position using SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
