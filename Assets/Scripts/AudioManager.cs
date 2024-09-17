using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")] [SerializeField]
    private AudioSource effectSource;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource uiSource;

    [Header("Effect Settings")] [SerializeField]
    private float effectVolume = 1.0f;

    [SerializeField] private float effectPitchVariance = 0.1f;

    [Header("Music Settings")] [SerializeField]
    private float musicVolume = 1.0f;

    [SerializeField] private bool musicLoop = true;

    [Header("UI Settings")] [SerializeField]
    private float uiVolume = 1.0f;

    [SerializeField] private float uiPitchVariance = 0.1f;

    public void PlayEffect(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void PlayUI(AudioClip clip)
    {
        uiSource.PlayOneShot(clip);
    }

    public void SetEffectVolume(float volume)
    {
        effectVolume = Mathf.Clamp01(volume);
        effectSource.volume = effectVolume;
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        musicSource.volume = musicVolume;
    }

    public void SetUIVolume(float volume)
    {
        uiVolume = Mathf.Clamp01(volume);
        uiSource.volume = uiVolume;
    }

    public void StopAll()
    {
        effectSource.Stop();
        musicSource.Stop();
        uiSource.Stop();
    }

    public void StopEffectSounds()
    {
        effectSource.Stop();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StopUISounds()
    {
        uiSource.Stop();
    }

    public void SetMusicPause(bool pause)
    {
        if (pause)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.UnPause();
        }
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
