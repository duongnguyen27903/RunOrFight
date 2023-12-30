using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Grounds : MonoBehaviour
{
    [SerializeField] private float DISTANCE_TO_GENERATE;
    [SerializeField] private Transform Generate_Ground_Position;
    [SerializeField] private Vector3 GenerateDistance;
    private GameObject ground;
    void Start()
    {
        ground = GameObject.Find("LongGround");
        GenerateDistance = ground.transform.Find("RightTop").position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawIcon(GenerateDistance, "EndPosition");
    }

    void Update()
    {
        GenerateDistance = ground.transform.Find("RightTop").position;
        if( Generate_Ground_Position.position.x - GenerateDistance.x > DISTANCE_TO_GENERATE)
        {
            ground = Grounds_Pool.instance.Get_new_ground();
            ground.transform.position = Generate_Ground_Position.transform.position;
            GenerateDistance = ground.transform.Find("RightTop").position;
            ground.SetActive(true);
        }
    }

    private IEnumerator AutoGenerate()
    {
        while (true)
        {
            
            GameObject obj = Grounds_Pool.instance.Get_new_ground();
            obj.transform.position = Generate_Ground_Position.transform.position;
            obj.SetActive(true);
            yield return null;
        }
    }
}
