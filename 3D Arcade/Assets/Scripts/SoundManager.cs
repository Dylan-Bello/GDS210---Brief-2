using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource soundFX;
    public AudioSource audioTheme;
    public AudioSource shootFX;

    public AudioClip soundTrack;
    void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        if (!audioTheme.playOnAwake)
        {
            audioTheme.clip = soundTrack;
            audioTheme.Play();
        }
    }

    void Update()
    {
        if(!audioTheme.isPlaying)
        {
            audioTheme.clip = soundTrack;
            audioTheme.Play();
        }
    }

    public void PlaySoundFX(AudioClip clip)
    {
        soundFX.clip = clip;
        soundFX.volume = Random.Range(.5f, .7f);
        soundFX.pitch = Random.Range(.8f, 1);
        soundFX.Play();
    }

    public void PlayShootFX(AudioClip clip)
    {
        shootFX.clip = clip;
        shootFX.volume = Random.Range(.5f, .7f);
        shootFX.pitch = Random.Range(.8f, 1);
        shootFX.Play();
    }

}
