using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource ambienceSource;
    [SerializeField] private AudioSource sfxSource;
    private List<AudioSource> sfxSources = new List<AudioSource>();

    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioClip[] ambienceClips;
    [SerializeField] private SoundClip[] sfxClipsLoop;
    [SerializeField] private AudioClip[] sfxClips;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize SFX sources pool
        for (int i = 0; i < 10; i++)  // example: prepare 10 audio sources for SFX
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.playOnAwake = false;
            sfxSources.Add(newSource);
        }
    }

    public void PlayMusic(int index)
    {
        musicSource.clip = musicClips[index];
        musicSource.loop = musicClips[index];
        musicSource.Play();
    }

    public void PlayAmbience(int index)
    {
        ambienceSource.clip = ambienceClips[index];
        ambienceSource.loop = ambienceClips[index];
        ambienceSource.Play();
    }
    public void PlaySFX(int index)
    {
        sfxSource.PlayOneShot(sfxClips[index]);
    }
    public void PlaySFXLoop(int index)
    {
        AudioSource source = sfxSources.Find(s => !s.isPlaying);
        if (source != null)
        {
            source.clip = sfxClipsLoop[index].clip;
            source.loop = sfxClipsLoop[index].loop;
            source.Play();
        }
    }

    public void StopSFX()
    {
        foreach (AudioSource source in sfxSources)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StopAmbience()
    {
        ambienceSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetAmbienceVolume(float volume)
    {
        ambienceSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        foreach (AudioSource source in sfxSources)
        {
            source.volume = volume;
        }
    }
}
