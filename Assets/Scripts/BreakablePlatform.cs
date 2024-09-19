using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float fallDelay = 1f;

    private float disappearDelay = 2f;
    private float respawnDelay = 1f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private SpriteRenderer spriteRenderer;
    private Collider2D platformCollider;


    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        spriteRenderer = GetComponent<SpriteRenderer>();
        platformCollider = GetComponent<Collider2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rigidBody.bodyType = RigidbodyType2D.Dynamic;

        
        yield return new WaitForSeconds(disappearDelay);
        spriteRenderer.enabled = false;
        platformCollider.enabled = false;


        yield return new WaitForSeconds(respawnDelay);
        RespawnPlatform();

    }

    private void RespawnPlatform()
    {
        //Reset Platform
        transform.position = startPosition;
        transform.rotation = startRotation;
        rigidBody.velocity = Vector2.zero;
        rigidBody.angularVelocity = 0f;
        rigidBody.bodyType = RigidbodyType2D.Kinematic;


        spriteRenderer.enabled = true;
        platformCollider.enabled = true;
    }

}
