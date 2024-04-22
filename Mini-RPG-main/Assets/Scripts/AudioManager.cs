using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [Header("RELEVA ISSO AQUI")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    
    [Header("Music Settings")]
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private float musicVolume;
    
    [Header("Attack Settings")]
    [SerializeField] private AudioClip attackSFX;
    [SerializeField] private float attackSFXVolume;
    
    [Header("Damage Settings")]
    [SerializeField] private AudioClip damageSFX;
    [SerializeField] private float damageSFXVolume;

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
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void OnAttackSound()
    {
        sfxSource.clip = attackSFX;
        sfxSource.volume = attackSFXVolume;
        sfxSource.Play();
    }

    public void OnDamageSound()
    {
        sfxSource.clip = damageSFX;
        sfxSource.volume = damageSFXVolume;
        sfxSource.Play();
    }
}
