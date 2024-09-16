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
    private bool isGrounded = false;

    private Rigidbody2D rb;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    
    void FixedUpdate()
    {

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
}
