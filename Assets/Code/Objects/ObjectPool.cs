using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected List<GameObject> prefabs;
    protected List<GameObject> objects = new();
    
    public GameObject GetNewObjects()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].activeInHierarchy == false)
            {
                return objects[i];
            }
        }
        GameObject new_platform = Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Count)]);
        new_platform.SetActive(false);
        objects.Add(new_platform);
        return new_platform;
    }
}
