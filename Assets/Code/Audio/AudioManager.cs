using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    [SerializeField] private SoundTrack[] Musics, SFXs;
    [SerializeField] private AudioSource MusicSource, SFXSource;
    public readonly string[] Music_song = { "MainTheme", "PlayTheme" };
    public readonly string[] Sfx_sound = { "button_click" };
    private void Awake()
    {
        if( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic( string song_name )
    {
        SoundTrack s = Array.Find(Musics, song => song.s_name == song_name);
        if( s == null)
        {
            print("Sound not found");
        }
        else
        {
            MusicSource.clip = s.s_clip;
            MusicSource.loop = true;
            MusicSource.Play();
        }
    }
    public void PlaySFX( string sfx_name )
    {
        SoundTrack s = Array.Find(SFXs, sfx => sfx.s_name == sfx_name);
        if (s == null)
        {
            print("Sound not found");
        }
        else
        {
            SFXSource.PlayOneShot(s.s_clip);
        }
    }
    public void MusicVolume( float volume)
    {
        MusicSource.volume = volume;
    }
    public void SfxVolume( float volume)
    {
        SFXSource.volume = volume;
    }
}
