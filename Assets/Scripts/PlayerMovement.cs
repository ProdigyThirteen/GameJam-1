using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [FormerlySerializedAs("movementSpeed")]
    [Header("Movement Settings")] 
    [SerializeField]
    private float movementImpulse = 2000.0f;
    [SerializeField]
    private float maxMoveSpeed = 10.0f;
    
    [Header("Jump Settings")] 
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private int maxJumps = 1;
    [SerializeField]
    private LayerMask groundLayer;
    
    // Internal variables
    private int _jumps = 0;
    private const float _groundCheckDistance = 0.1f;
    
    // Internal references
    private Rigidbody2D _rb;
    private Collider2D _playerCollider;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Move();
        Jump();
        
        if (IsGrounded() && _rb.velocity.y <= 0)
        {
            _jumps = 0;
        }
    }

    private void Move()
    {
        float input = Input.GetAxisRaw("Horizontal");
        _rb.AddForce(input * movementImpulse * Time.deltaTime * Vector2.right);
        
        if (Mathf.Abs(_rb.velocity.x) > maxMoveSpeed)
        {
            _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * maxMoveSpeed, _rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _jumps < maxJumps)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _jumps++;
        }
    }

    private bool IsGrounded()
    {
        // Get collider bounds to offset position of raycast
        Vector2 position = transform.position;
        Vector2 size = _playerCollider.bounds.size;
        
        Vector2 origin = new Vector2(position.x, position.y - size.y / 2);
        
        // Cast a ray downwards from the player's position
        RaycastHit2D hit = Physics2D.Raycast(
            origin,     
            Vector2.down,                
            _groundCheckDistance,                        
            groundLayer                         
        );
        
        // If the ray hits the ground, the player is grounded
        return hit.collider != null;
    }

    public void AddMaxJump()
    {
        maxJumps++;
    }
    
    public void RemoveMaxJump()
    {
        maxJumps--;
    }
    
    public void AddMovementImpulse(float speed)
    {
        movementImpulse += speed;
    }
    
    public void RemoveMovementImpulse(float speed)
    {
        movementImpulse -= speed;
    }
    
    public void AddMaxMoveSpeed(float speed)
    {
        maxMoveSpeed += speed;
    }
    
    public void RemoveMaxMoveSpeed(float speed)
    {
        maxMoveSpeed -= speed;
    }
}
