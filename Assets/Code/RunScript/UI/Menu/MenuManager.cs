using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Achivement achivement;
    private void Start()
    {
        achivement = FindObjectOfType<Achivement>();
    }
    public void Play_Pressed()
    {
        SceneManager.LoadScene("RunScene");
    }
    public void Store_Pressed()
    {
        SceneManager.LoadScene("Store");
    }
    public void Achivement_Pressed()
    {
        achivement.Appear();
    }
    public void AboutUs_Presses()
    {

    }
    public void Setting_Pressed()
    {

    }
}
