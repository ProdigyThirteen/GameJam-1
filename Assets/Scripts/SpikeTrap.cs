using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeTrap : MonoBehaviour
{

    [SerializeField]
    private GameObject deathScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check for barrier
            if (other.GetComponent<PlayerBarrier>().IsActive())
            {
                return;
            }

            Animator playerAnimator = other.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("Dead"); // Assumes "Death" is the trigger for the death animation
            }

            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            StartCoroutine(ReloadSceneAfterDelay(1.2f));

        }
    }

    private IEnumerator ReloadSceneAfterDelay(float delay)
    {

        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }

        yield return new WaitForSeconds(delay);

        DeathManager.IncrementDeathCount();
        int newDeathCount = DeathManager.GetDeathCount();

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
