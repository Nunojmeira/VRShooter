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
        SoundFXAudioSource.PlayOneShot(sound.clip);
    }
}
