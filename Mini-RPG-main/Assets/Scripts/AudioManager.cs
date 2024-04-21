using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [Header("Music Settings")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private float musicVolume;
    
    [Header("SFX Settings")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private float hitSoundVolume;
    [SerializeField] private float damageSoundVolume;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void OnHitSound(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.volume = hitSoundVolume;
        sfxSource.Play();
    }

    public void OnDamageSound(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.volume = damageSoundVolume;
        sfxSource.Play();
    }
}
