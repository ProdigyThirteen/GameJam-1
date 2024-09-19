using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    [SerializeField] private bool isBarrierActive = false;
    [SerializeField] private bool isBarrierEnabled = false;
    [SerializeField] private float barrierCooldown = 15.0f;
    [SerializeField] private AudioClip barrierPopSound;

    private GameObject _barrier;
    private ParticleSystem _barrierParticles;
    
    private void Start()
    {
        GenerateBarrier();
        _barrierParticles = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!isBarrierEnabled || isBarrierActive) return;
        
        barrierCooldown -= Time.deltaTime;
        if (barrierCooldown <= 0)
        {
            isBarrierActive = true;
            _barrier.SetActive(isBarrierActive);
            barrierCooldown = 15.0f;
        }
    }

    private void GenerateBarrier()
    {
        _barrier = new GameObject("Barrier")
        {
            transform =
            {
                parent = transform,
                localScale = new Vector3(1.25f, 1.25f, 1.25f),
                localPosition = new Vector3(0, 0, 0),
                localRotation = Quaternion.identity
            }
        };
        var sr = _barrier.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("Sprites/Barrier");
        sr.sortingLayerName = "Player";
        sr.sortingOrder = 1;
        
        // Generate a collider for the barrier
        PolygonCollider2D barrierCollider = _barrier.AddComponent<PolygonCollider2D>();
        barrierCollider.isTrigger = true;
        
        
        
        
        // Set barrier to disabled
        _barrier.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Trap")) return;
        
        if (!isBarrierEnabled || !isBarrierActive) return;
        
        isBarrierActive = false;
        _barrier.SetActive(isBarrierActive);
            
        // Throw the player in a random direction
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f)) * 500.0f);
        
        // Play the barrier pop sound
        AudioManager.Instance.PlayEffect(barrierPopSound);
        
        // Play the particles
        _barrierParticles.Play();
    }
    
    public void EnableBarrier()
    {
        isBarrierEnabled = true;
        isBarrierActive = true;
        _barrier.SetActive(isBarrierActive);
    }
    
    public bool IsActive()
    {
        return isBarrierActive;
    }
}
