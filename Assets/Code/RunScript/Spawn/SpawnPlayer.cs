using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHero : MonoBehaviour
{
    [SerializeField] private List<GameObject> Heroes;
    [SerializeField] private int Selected_Hero;
    private void Awake()
    {
        Selected_Hero = PlayerPrefs.GetInt("selected_hero", 0);
        GameObject hero = Instantiate(Heroes[Selected_Hero]);
        hero.transform.position = transform.position;
        hero.SetActive(true);
    }
    private void Reset()
    {
        print("reset");
    }

}
