using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBurstPool : MonoBehaviour
{
    private static PowerBurstPool instance;
    public static PowerBurstPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PowerBurstPool>();
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

    [SerializeField] private GameObject FireBurst_prefab;
    [SerializeField] private GameObject IceBurst_prefab;
    private List<GameObject> FireBurstList = new();
    private List<GameObject> IceBurstList = new();

    public GameObject Get_New_FireBurst()
    {
        for (int i = 0; i < FireBurstList.Count; i++)
        {
            if (FireBurstList[i].activeInHierarchy == false)
            {
                return FireBurstList[i];
            }
        }
        GameObject new_platform = Instantiate(FireBurst_prefab);
        new_platform.SetActive(false);
        FireBurstList.Add(new_platform);
        return new_platform;
    }
    public GameObject Get_New_IceBurst()
    {
        for (int i = 0; i < IceBurstList.Count; i++)
        {
            if (IceBurstList[i].activeInHierarchy == false)
            {
                return IceBurstList[i];
            }
        }
        GameObject new_platform = Instantiate(IceBurst_prefab);
        new_platform.SetActive(false);
        IceBurstList.Add(new_platform);
        return new_platform;
    }
}
