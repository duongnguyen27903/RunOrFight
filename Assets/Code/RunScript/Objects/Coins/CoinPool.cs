using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : ObjectPool
{
    private static CoinPool instance;
    public static CoinPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CoinPool>();
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
}
