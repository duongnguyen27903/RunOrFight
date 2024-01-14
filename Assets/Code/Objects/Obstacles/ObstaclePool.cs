using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : ObjectPool
{
    private static ObstaclePool Instance;
    public static ObstaclePool instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<ObstaclePool>();
            }
            return Instance;
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
