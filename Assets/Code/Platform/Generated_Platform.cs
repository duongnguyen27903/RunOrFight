using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Generated_Platform : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    private PlayerController player;
    [SerializeField] private Vector3 lastPosition;

    private void Awake()
    {
        GameObject lastLevel = GameObject.Find("ShortPlatform/Left");
        if( lastLevel != null)
        {
            Debug.Log(lastLevel);
        }
        lastPosition = lastLevel.transform.position;
        player = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if(lastPosition.x - player.GetPlayerPosition().x  < 20f)
        {
            GameObject new_platform = Platform_Pool.instance.Get_new_platform();
            new_platform.transform.position = lastPosition + new Vector3(Random.Range(3f, 4f), Random.Range(-2f,2f), 0);
            lastPosition = new_platform.transform.Find("Left").position;
            new_platform.SetActive(true);
        }
    }
}
