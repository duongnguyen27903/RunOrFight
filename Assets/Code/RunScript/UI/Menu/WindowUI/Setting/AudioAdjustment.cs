using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioAdjustment : MonoBehaviour
{
    [SerializeField] private Slider Music_Slider, SFX_Slider;

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(Music_Slider.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SfxVolume(SFX_Slider.value);
    }
}
