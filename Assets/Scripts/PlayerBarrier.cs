using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    [SerializeField] private bool isBarrierActive = false;
    [SerializeField] private bool isBarrierEnabled = false;
    [SerializeField] private float barrierCooldown = 15.0f;

    private GameObject barrier;
    
    private void Start()
    {
        GenerateBarrier();
    }

    private void Update()
    {
        if (!isBarrierEnabled || isBarrierActive) return;
        
        barrierCooldown -= Time.deltaTime;
        if (barrierCooldown <= 0)
        {
            isBarrierActive = true;
            barrier.SetActive(isBarrierActive);
            barrierCooldown = 15.0f;
        }
    }

    private void GenerateBarrier()
    {
        barrier = new GameObject("Barrier");
        barrier.transform.parent = transform;
        SpriteRenderer sr = barrier.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("Sprites/Barrier");
        sr.sortingLayerName = "Player";
        sr.sortingOrder = 1;
        barrier.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
        barrier.transform.localPosition = new Vector3(0, 0, 0);
        barrier.transform.localRotation = Quaternion.identity;
        
        // Generate a collider for the barrier
        PolygonCollider2D collider = barrier.AddComponent<PolygonCollider2D>();
        collider.isTrigger = true;
        
        
        // Set barrier to disabled
        barrier.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Trap")) return;
        
        if (!isBarrierEnabled || !isBarrierActive) return;
        
        isBarrierActive = false;
        barrier.SetActive(isBarrierActive);
            
        // Throw the player in a random direction
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f)) * 500.0f);
    }
    
    public void EnableBarrier()
    {
        isBarrierEnabled = true;
        isBarrierActive = true;
        barrier.SetActive(isBarrierActive);
    }
}
