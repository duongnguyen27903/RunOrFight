using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBurst : MonoBehaviour
{
    private float life_time;
    private void OnEnable()
    {
        life_time = 1f;
    }
    private void Update()
    {
        if (life_time < 0f) 
        { 
            gameObject.SetActive(false);
        }
        life_time -= Time.deltaTime;
    }
}
