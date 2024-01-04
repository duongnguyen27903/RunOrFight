using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounds_Pool : MonoBehaviour
{
    private static Grounds_Pool Instance;
    public static Grounds_Pool instance
    {
        get
        {
            if( Instance == null)
            {
                Instance = FindObjectOfType<Grounds_Pool>();
            }
            return Instance;
        }
    }
    [SerializeField] private List<GameObject> prefabs;
    private List<GameObject> grounds = new();
    private GameObject Generate_Grounds;
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
        Generate_Grounds = GameObject.Find("Generate_Grounds");
    }

    public void Add_Grounds(GameObject obj)
    {
        foreach( GameObject ground in grounds)
        {
            if( ground == obj)
            {
                return;
            }
        }
        obj.SetActive(false);
        obj.transform.SetParent(Generate_Grounds.transform);
        grounds.Add(obj);
    }

    private void Start()
    {
        for( int i=0 ; i<2; i++ )
        {
            for( int j=0; j< prefabs.Count; j++ )
            {
                GameObject new_platform = Instantiate(prefabs[j]);
                new_platform.SetActive(false);
                new_platform.transform.SetParent(Generate_Grounds.transform);
                grounds.Add(new_platform);
            }
        }
    }

    public GameObject Get_new_ground()
    {
        for( int i = 0; i < grounds.Count; i++)
        {
            if(grounds[i].activeInHierarchy == false)
            {
                int x = Random.Range(0, prefabs.Count);
                if(prefabs[x].CompareTag(grounds[i].tag))
                return grounds[i];
            }
        }
        
        GameObject new_platform = Instantiate(prefabs[Random.Range(0,prefabs.Count)]);
        new_platform.SetActive(false);
        new_platform.transform.SetParent(Generate_Grounds.transform);
        grounds.Add(new_platform);
        return new_platform;
    }
}
