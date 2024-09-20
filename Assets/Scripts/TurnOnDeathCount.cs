using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnOnDeathCount : MonoBehaviour
{

    public TextMeshProUGUI deathCountText;

    [SerializeField]
    private GameObject deathEndAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UpdateDeathCountText();

            if (deathEndAmount != null)
            {
                deathEndAmount.SetActive(true);
            }


        }

    }

    public void UpdateDeathCountText()
    {
        int deadFrogCount = PlayerPrefs.GetInt("DeathCount", 0);
        deathCountText.text = deadFrogCount.ToString();
    }

}
