using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SwitchPower : MonoBehaviour
{
    [SerializeField] private GameObject FirePower;
    [SerializeField] private GameObject IcePower;
    private bool IsFireOn;
    private void Awake()
    {
        
    }
    public void ActiveFirePower()
    {
        FirePower.SetActive(true);
        IcePower.SetActive(false);
    }

    public void ActiveIcePower()
    {
        FirePower.SetActive(false);
        IcePower.SetActive(true);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
