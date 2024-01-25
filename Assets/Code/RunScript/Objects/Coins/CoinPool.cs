using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : ObjectPool
{
    private static CoinPool Instance;
    public static CoinPool instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<CoinPool>();
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
