using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayPanel : MonoBehaviour
{
    [SerializeField] private GameObject Fire;
    [SerializeField] private GameObject Ice;
    public void ActiveFire()
    {
        Fire.SetActive(true);
        Ice.SetActive(false);
    }
    public void ActiveIce()
    {
        Ice.SetActive(true);
        Fire.SetActive(false);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
