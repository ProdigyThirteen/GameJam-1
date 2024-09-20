using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScreenUI : MonoBehaviour
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
        deathCountText.text = deadFrogCount.ToString();  
    }

    //Incase of weird screen size changing
    void AdjustFontSize()
    {
        
        float screenHeight = Screen.height;
        int newFontSize = Mathf.FloorToInt(screenHeight / 20);
        deathCountText.fontSize = newFontSize;
    }

}
