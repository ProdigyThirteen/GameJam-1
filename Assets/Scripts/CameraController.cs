using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The player's transform (drag and drop the player here in the Inspector)
    private Transform player;

    // Time for the camera to reach the player
    [SerializeField] private float smoothTime = 0.3f;

    // Offset for the camera to follow the player
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10);

    // Required for SmoothDamp to track the current velocity
    private Vector3 velocity = Vector3.zero; 

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Target position for the camera (player's position plus the offset)
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera towards the target position using SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}