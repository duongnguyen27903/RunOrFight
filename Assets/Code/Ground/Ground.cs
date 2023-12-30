using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
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
