using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Pool : MonoBehaviour
{
    private static Platform_Pool Instance;
    public static Platform_Pool instance
    {
        get
        {
            if( Instance == null)
            {
                Instance = FindObjectOfType<Platform_Pool>();
            }
            return Instance;
        }
    }
    [SerializeField] private GameObject prefab;
    private List<GameObject> platforms = new();

    private void Awake()
    {
        if( Instance == null)
        {
            Instance = this;
        }
        else if( Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public GameObject Get_new_platform()
    {
        for( int i = 0; i < platforms.Count; i++)
        {
            if(platforms[i].activeInHierarchy == false)
            {
                return platforms[i];
            }
        }

        GameObject new_platform = Instantiate(prefab);
        new_platform.SetActive(false);
        platforms.Add(new_platform);
        return new_platform;
    }
}
