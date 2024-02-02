using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounds_Pool : MonoBehaviour
{
    private static Grounds_Pool instance;
    public static Grounds_Pool Instance
    {
        get
        {
            if( instance == null)
            {
                instance = FindObjectOfType<Grounds_Pool>();
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
        Spawn_GroundObjParent = GameObject.Find("Spawn_GroundObjParent");
    }
    [SerializeField] private List<GameObject> prefabs;
    private List<GameObject> grounds = new();
    private GameObject Spawn_GroundObjParent;
    

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
        obj.transform.SetParent(Spawn_GroundObjParent.transform);
        grounds.Add(obj);
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < prefabs.Count; j++)
            {
                GameObject new_platform = Instantiate(prefabs[j]);
                new_platform.SetActive(false);
                new_platform.transform.SetParent(Spawn_GroundObjParent.transform);
                grounds.Add(new_platform);
            }
        }
    }

    public GameObject Get_new_ground(string tag)
    {
        for( int i = 0; i < grounds.Count; i++)
        {
            if(grounds[i].activeInHierarchy == false && grounds[i].CompareTag(tag))
            {
                return grounds[i];
            }
        }
        GameObject new_platform = Instantiate(prefabs.Find(obj => obj.CompareTag(tag)));
        new_platform.SetActive(false);
        new_platform.transform.SetParent(Spawn_GroundObjParent.transform);
        grounds.Add(new_platform);
        return new_platform;
    }
}
