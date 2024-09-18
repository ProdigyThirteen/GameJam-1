using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{ 
    private AudioClip levelMusic;
    
    private void Start()
    {
        levelMusic = Resources.Load<AudioClip>("Music/time_for_adventure");
        AudioManager.Instance.SetMusicLoop(true);
        AudioManager.Instance.PlayMusic(levelMusic);
    }
}
