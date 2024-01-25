using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play_Pressed()
    {
        SceneManager.LoadScene("RunScene");
    }
    public void Store_Pressed()
    {
        SceneManager.LoadScene("Store");
    }
    public void LeaderBoard_Pressed()
    {

    }
    public void AboutUs_Presses()
    {

    }
    public void Setting_Pressed()
    {

    }
}
