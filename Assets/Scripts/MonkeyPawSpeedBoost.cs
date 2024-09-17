using System.Collections;
using System.Collections.Generic;
using QFSW.QC;
using UnityEngine;
using UnityEngine.Serialization;

public class MonkeyPawSpeedBoost : MonoBehaviour
{
    [SerializeField] private float movementImpulseBoost = 2000.0f;
    [SerializeField] private float maxMoveSpeedBoost = 5.0f;
    [SerializeField] private PhysicsMaterial2D slipperyMaterial;
    
    private GameObject _player;
    private PlayerMovement _playerMovement;
    private BoxCollider2D _playerCollider;
    
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player != null)
        {
            _playerMovement = _player.GetComponent<PlayerMovement>();
            _playerCollider = _player.GetComponent<BoxCollider2D>();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        Collect();
    }

    [Command("AddSpeedBoost")]
    private void Collect()
    {
        // Give the player a speed boost
        if (_playerMovement != null)
        {
            _playerMovement.AddMovementImpulse(movementImpulseBoost);
            _playerMovement.AddMaxMoveSpeed(maxMoveSpeedBoost);
        }

        if (_playerCollider != null && slipperyMaterial != null)
        {
            _playerCollider.sharedMaterial = slipperyMaterial;
        }
            
        Destroy(gameObject);
    }
    
}
