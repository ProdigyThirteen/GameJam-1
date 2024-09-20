using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountOfFrogsKilledInTheEnd : MonoBehaviour
{
    public TextMeshProUGUI deathCountText;


    void Start()
    {
        UpdateDeathCountText();
        AdjustFontSize();
    }

    public void UpdateDeathCountText()
    {
        int deadFrogCount = PlayerPrefs.GetInt("DeathCount", 0);
        deathCountText.text = "You've killed " + deadFrogCount.ToString() + " frogs";
    }

    void AdjustFontSize()
    {

        float screenHeight = Screen.height;
        int newFontSize = Mathf.FloorToInt(screenHeight / 25);
        deathCountText.fontSize = newFontSize;
    }
}
