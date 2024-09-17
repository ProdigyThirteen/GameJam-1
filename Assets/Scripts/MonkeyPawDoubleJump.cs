using System.Collections;
using System.Collections.Generic;
using System.Security;
using QFSW.QC;
using UnityEngine;

public class MonkeyPawDoubleJump : MonoBehaviour
{
    [Tooltip("Parent object of all traps to enable when the player picks up the double jump upgrade.")]
    [SerializeField] private GameObject trapsToEnable;
    
    private GameObject player;
    private PlayerMovement playerMovement;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
            playerMovement = player.GetComponent<PlayerMovement>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Collect();
    }

    [Command("AddDoubleJump")]
    private void Collect()
    {
        // Iterate through all children of the trapsToEnable object and set them to active
        if (trapsToEnable != null)
        {
            for (var i = 0; i < trapsToEnable.transform.childCount; i++)
            {
                trapsToEnable.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("No trapsToEnable object set in the Inspector. Please set one to enable traps.");
        }
        
        // Give the player an extra jump
        if (playerMovement != null)
            playerMovement.AddMaxJump();
            
        Destroy(gameObject);
    }
}
