using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float fallDelay = 1f;

    private float destroySelfDelay = 2f;

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
        Destroy(gameObject, destroySelfDelay);
    }
  
}
