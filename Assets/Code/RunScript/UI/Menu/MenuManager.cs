using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Achivement achivement;
    [SerializeField] private AboutUs aboutUs;
    [SerializeField] private Setting setting;

    public void Play_Pressed()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Sfx_sound[0]);
        SceneManager.LoadSceneAsync("RunScene");
    }
    public void Store_Pressed()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Sfx_sound[0]);
        SceneManager.LoadSceneAsync("Store");
    }
    public void Achivement_Pressed()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Sfx_sound[0]);
        achivement.Appear();
    }
    public void AboutUs_Presses()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Sfx_sound[0]);
        aboutUs.Appear();
    }
    public void Setting_Pressed()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Sfx_sound[0]);
        setting.Appear();
    }

    private void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.Music_song[0]);
    }
}
