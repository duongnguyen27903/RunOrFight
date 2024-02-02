using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private Material sky_sun;
    [SerializeField] private Material houses3;
    [SerializeField] private Material houses2;
    [SerializeField] private Material housesfountain;
    [SerializeField] private Material trees;
    [SerializeField] private float skysun_speed;
    [SerializeField] private float houses3_speed;
    [SerializeField] private float houses2_speed;
    [SerializeField] private float housesfountain_speed;
    [SerializeField] private float trees_speed;

    [SerializeField] private int MainTexID;

    private Vector2 offset1;
    private Vector2 offset2;
    private Vector2 offset3;
    private Vector2 offset4;
    private Vector2 offset5;
    void Start()
    {
        MainTexID = Shader.PropertyToID("_MainTex");
        offset1 = sky_sun.GetTextureOffset(MainTexID);
        offset2 = houses3.GetTextureOffset(MainTexID);
        offset3 = houses2.GetTextureOffset(MainTexID);
        offset4 = housesfountain.GetTextureOffset(MainTexID);
        offset5 = trees.GetTextureOffset(MainTexID);
    }

    void Update()
    {
        offset1 += new Vector2(skysun_speed * Time.deltaTime,0);
        sky_sun.SetTextureOffset(MainTexID, offset1);

        offset2 += new Vector2(houses3_speed * Time.deltaTime,0);
        houses3.SetTextureOffset(MainTexID, offset2);

        offset3 += new Vector2(houses2_speed * Time.deltaTime, 0);
        houses2.SetTextureOffset(MainTexID, offset3);

        offset4 += new Vector2(housesfountain_speed * Time.deltaTime, 0);
        housesfountain.SetTextureOffset(MainTexID, offset4);

        offset5 += new Vector2(trees_speed * Time.deltaTime, 0);
        trees.SetTextureOffset(MainTexID, offset5);
    }

    private void Reset()
    {
        //offset1 = Vector2.zero;
        //sky_sun.SetTextureOffset(MainTexID, offset1);
        //offset2 = Vector2.zero;
        //houses3.SetTextureOffset(MainTexID, offset2);
        //offset3 = Vector2.zero;
        //houses2.SetTextureOffset(MainTexID, offset3);
        //offset4 = Vector2.zero;
        //housesfountain.SetTextureOffset(MainTexID, offset4);
        //offset5 = Vector2.zero;
        //trees.SetTextureOffset(MainTexID, offset5);
        print("reset");
    }
}
