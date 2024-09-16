using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")] 
    [SerializeField]
    private float movementSpeed = 5.0f;
    [SerializeField]
    private float maxMoveSpeed = 10.0f;
    
    [Header("Jump Settings")] 
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private int maxJumps = 1;
    
    // Private variables
    private int jumps = 0;

    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Move();
        Jump();
    }
    
    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * movementSpeed, rb.velocity.y);
        
        if (rb.velocity.magnitude > maxMoveSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxMoveSpeed * Time.deltaTime;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumps < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumps++;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        // Ground check
        if (!other.gameObject.CompareTag("Ground")) return;
        
        jumps = 0;
    }

    public void AddMaxJump()
    {
        maxJumps++;
    }
    
    public void RemoveMaxJump()
    {
        maxJumps--;
    }
}
