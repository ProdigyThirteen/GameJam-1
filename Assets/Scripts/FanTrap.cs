using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTrap : MonoBehaviour
{
    [SerializeField]
    private float maxPushForce = 15f; 
    [SerializeField]
    private float minPushForce = 3f;  
    [SerializeField]
    private float influenceRadius = 5f;

    [Tooltip("Direction in which the fan will push the player. X and Y values represent the direction.")]
    [SerializeField]
    private Vector2 pushDirection = Vector2.right; // Default is right


    //public Animator animatorFan;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                // Calculate the distance between the fan and the player
                float distance = Vector2.Distance(transform.position, collision.transform.position);

                float pushForce = Mathf.Lerp(maxPushForce, minPushForce, distance / influenceRadius);

                //Force only scales within the influence radius
                if (distance > influenceRadius)
                {
                    pushForce = minPushForce;
                }

                Vector2 normalizedDirection = pushDirection.normalized;

                playerRb.AddForce(normalizedDirection * pushForce);

                //animatorFan.SetTrigger("PlayerEnter");
            }
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        //Blue line which shows which way the fan will push the player
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)pushDirection.normalized * 2f);

        //Yellow sphere which shows the influence radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, influenceRadius);
    }
}
