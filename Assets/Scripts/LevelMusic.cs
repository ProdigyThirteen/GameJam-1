using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{ 
    [SerializeField] private AudioClip levelMusic;
    
    private void Start()
    {
        AudioManager.Instance.SetMusicLoop(true);
        AudioManager.Instance.PlayMusic(levelMusic);
    }
}
