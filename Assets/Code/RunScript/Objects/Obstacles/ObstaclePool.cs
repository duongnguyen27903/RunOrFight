using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : ObjectPool
{
    private static ObstaclePool instance;
    public static ObstaclePool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObstaclePool>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GenerateOnStart();
    }
}
