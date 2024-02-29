using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] private AudioSource m_Music;
    [SerializeField] private AudioClip MenuMusic;

    [SerializeField] private AudioSource m_SFX;
    [SerializeField] private AudioClip Click_Btn_SFX;
    
    public void PlayMainTheme()
    {
        m_Music.loop = true;
        m_Music.clip = MenuMusic;
        m_Music.Play();
    }
    public void ClickSound()
    {
        m_SFX.loop = false;
        m_SFX.clip = Click_Btn_SFX;
        m_SFX.Play();
    }

    private void Start()
    {
        PlayMainTheme();
    }

}
