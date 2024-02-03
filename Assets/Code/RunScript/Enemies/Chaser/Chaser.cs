using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Enemy
{
    [SerializeField] private Rigidbody2D rb;
    private Vector3 SpawnChaser = new(-8.5f,4f);
    
    private void Start()
    {
        AssignAnimation();
        PlayRunAnimation();
    }
    private void Update()
    {
        if( transform.position.y <= -8 || transform.position.x <= -20)
        {
            transform.position = SpawnChaser;
        }
        
    }
}
