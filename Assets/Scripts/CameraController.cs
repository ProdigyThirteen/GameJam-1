using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    // The player's transform (drag and drop the player here in the Inspector)
    private Transform player;
    private Rigidbody2D playerRb;

    [Header("Follow Settings")]
    // Time for the camera to reach the player
    [SerializeField] private float followSmoothTime = 0.3f;

    // Offset for the camera to follow the player
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10);
    
    [Header("Zoom Settings")]
    // Zoom settings
    [SerializeField] private float zoomSmoothTime = 0.3f;
    [SerializeField] private float minZoom = 10.0f;
    [SerializeField] private float maxZoom = 25.0f;
    
    // Required for SmoothDamp to track the current follow velocity
    private Vector3 followVelocity = Vector3.zero; 

    // Required for SmoothDamp to track the current zoom velocity
    private float currentZoom;
    private float zoomVelocity = 0.0f;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Zoom camera out as player moves faster
        // Calculate the target zoom based on player velocity
        float targetZoom = Mathf.Lerp(minZoom, maxZoom, playerRb.velocity.magnitude / 10); // Adjust division factor as needed
        
        // Smoothly interpolate between current and target zoom
        currentZoom = Mathf.SmoothDamp(currentZoom, targetZoom, ref zoomVelocity, zoomSmoothTime);
        
        // Apply the new zoom to the camera
        if (Camera.main != null) Camera.main.orthographicSize = currentZoom;

        // Target position for the camera (player's position plus the offset)
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera towards the target position using SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref followVelocity, followSmoothTime);
    }
    
    public void SetTarget(GameObject target, Rigidbody2D targetRb)
    {
        player = target.transform;
        playerRb = targetRb;
    }
    
    public GameObject GetTarget()
    {
        return player.gameObject;
    }
}