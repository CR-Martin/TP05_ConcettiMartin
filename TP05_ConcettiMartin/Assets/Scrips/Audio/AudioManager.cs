using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private Clip[] musicSounds, sfxSounds;
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private AudioSource musicSource;

    private string lastSong;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(string musicName)
    {
        Clip sound = Array.Find(musicSounds, x => x.soundName == musicName);
        if (sound == null)
        {
            Debug.LogError("Sound not found");
        }
        else
        {
            if (musicName == lastSong) return;
            lastSong = sound.soundName;
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

}