using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private float moveSpeed=0;
    [SerializeField] private int current_level=0;

    private void Awake()
    {
        current_level = 0;
        moveSpeed = 3;
    }

    private void OnEnable()
    {
        int update_level = GameManager.instance.Get_current_level();
        if( current_level != update_level)
        {
            current_level = update_level;
            moveSpeed = GameManager.instance.Get_ground_movespeed(current_level);
        }
        Debug.Log($"current level : {current_level}, movespeed : {moveSpeed} ");
    }

    private Transform resetPosition;
    private void Start()
    {
        resetPosition = GameObject.Find("ResetPosition").transform;
    }
    void Update()
    {
        gameObject.transform.position -= new Vector3( moveSpeed * Time.deltaTime,0);
        if( gameObject.transform.position.x <= resetPosition.transform.position.x)
        {
            Grounds_Pool.instance.Add_Grounds(gameObject);
            gameObject.SetActive(false);
        }
    }
}
