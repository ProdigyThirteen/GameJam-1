using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{

    //Honestly this is the only way I know how to do it. I don't know what I'm doing xD - Jack T

    public static void IncrementDeathCount()
    {
        int deadFrogCount = PlayerPrefs.GetInt("DeathCount", 0);
        deadFrogCount++;

        PlayerPrefs.SetInt("DeathCount", deadFrogCount);
        PlayerPrefs.Save();
    }

    
    public static int GetDeathCount()
    {
        return PlayerPrefs.GetInt("DeathCount", 0);
    }

    
    public static void ResetDeathCount()
    {
        PlayerPrefs.SetInt("DeathCount", 0);
        PlayerPrefs.Save();
    }
}
