using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    //diem so score khi dat den se len 1 level ke tiep
    public float Checkpoint;
    //toc do di chuyen cua ground
    public float MoveSpeed;
    //khoang cach giua 2 ground 
    public float MAX_DISTANCE;
}
