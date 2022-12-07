using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource BGAudioSource;
    [SerializeField] AudioSource SoundFXAudioSource;
    [SerializeField] List<Sound> sounds;
    [SerializeField] List<AudioClip> music;


    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
           
    }

    void Start()
    {
        PlayRandomSong();
        EventManager.OnGameOverStart += OnGameOver;
        EventManager.OnGameOverEnd += OnGameOverEnd;
    }

    public void PauseBGMusic()
    {
        BGAudioSource.Pause();
    }

    public void UnPauseBGMusic()
    {
        BGAudioSource.Play();
    }

    public void PlayRandomSong()
    {
        if (BGAudioSource.isPlaying)
            BGAudioSource.Stop();
        BGAudioSource.clip = music[Random.Range(0, music.Count)];
        BGAudioSource.Play();
    }

    public void PlaySound(string soundName)
    {
        var sound = sounds.Find(x => x.name == soundName);
        if (sound == null) return;
        switch (sound.name)
        {
            case "HealthLoss":
                sound.volume = 0.5f;
                SoundFXAudioSource.volume = 1f;
                break;
            case "BackOff":
                sound.volume = 1f;
                SoundFXAudioSource.volume = 1.5f;
                break;
            default:
                sound.volume = 0.1f;
                SoundFXAudioSource.volume = 0.5f;
                break;
        }

        SoundFXAudioSource.PlayOneShot(sound.clip);
    }

    void OnGameOver()
    {
        if (BGAudioSource.isPlaying)
            BGAudioSource.Stop();
    }

    void OnGameOverEnd()
    {
        PlayRandomSong();
    }
}
