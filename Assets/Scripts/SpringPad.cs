using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPad : MonoBehaviour
{
    [SerializeField]
    private float bounceForce = 11f;

    public Animator animatorSpring;

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rigidBody = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 velocity = rigidBody.velocity;
            velocity.y = 0;
            rigidBody.velocity = velocity;

            rigidBody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

            animatorSpring.SetTrigger("PlayerEnter");
        }

    }
}
