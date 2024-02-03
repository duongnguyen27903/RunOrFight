using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Achivement achivement;
    private AboutUs aboutUs;
    private Setting setting;
    private void Start()
    {
        print("reload scene");
        achivement = FindObjectOfType<Achivement>();
        aboutUs = FindObjectOfType<AboutUs>();
        setting = FindObjectOfType<Setting>();
    }
    public void Play_Pressed()
    {
        SceneManager.LoadSceneAsync("RunScene");
    }
    public void Store_Pressed()
    {
        SceneManager.LoadSceneAsync("Store");
    }
    public void Achivement_Pressed()
    {
        achivement.Appear();
    }
    public void AboutUs_Presses()
    {
        aboutUs.Appear();
    }
    public void Setting_Pressed()
    {
        setting.Appear();
    }
}
