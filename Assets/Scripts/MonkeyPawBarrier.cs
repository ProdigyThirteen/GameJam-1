using System.Collections;
using System.Collections.Generic;
using QFSW.QC;
using UnityEngine;

public class MonkeyPawBarrier : MonoBehaviour
{
    private GameObject player;
    private PlayerBarrier playerBarrier;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
            playerBarrier = player.GetComponent<PlayerBarrier>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Collect();
    }
    
    [Command("AddBarrier")]
    private void Collect()
    {
        if (playerBarrier != null)
            playerBarrier.EnableBarrier();
        
        Destroy(gameObject);
    }
}
