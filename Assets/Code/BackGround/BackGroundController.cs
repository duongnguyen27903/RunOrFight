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
    void Start()
    {
        MainTexID = Shader.PropertyToID("_MainTex");
    }

    void Update()
    {
        Vector2 offset1 = sky_sun.GetTextureOffset(MainTexID);
        offset1 += new Vector2(skysun_speed * Time.deltaTime,0);
        sky_sun.SetTextureOffset(MainTexID, offset1);

        Vector2 offset2 = houses3.GetTextureOffset(MainTexID);
        offset2 += new Vector2(houses3_speed * Time.deltaTime,0);
        houses3.SetTextureOffset(MainTexID, offset2);

        Vector2 offset3 = houses2.GetTextureOffset(MainTexID);
        offset3 += new Vector2(houses2_speed * Time.deltaTime, 0);
        houses2.SetTextureOffset(MainTexID, offset3);

        Vector2 offset4 = housesfountain.GetTextureOffset(MainTexID);
        offset4 += new Vector2(housesfountain_speed * Time.deltaTime, 0);
        housesfountain.SetTextureOffset(MainTexID, offset4);

        Vector2 offset5 = trees.GetTextureOffset(MainTexID);
        offset5 += new Vector2(trees_speed * Time.deltaTime, 0);
        trees.SetTextureOffset(MainTexID, offset5);
    }
}
