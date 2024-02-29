using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHero : MonoBehaviour
{
    [SerializeField] private List<GameObject> Heroes;
    [SerializeField] private int Selected_Hero;
    [SerializeField] private GameObject Chaser;
    [SerializeField] private Camera Cam;
    private void Awake()
    {
        Selected_Hero = PlayerPrefs.GetInt("selected_hero", 0);
        GameObject hero = Instantiate(Heroes[Selected_Hero]);
        hero.transform.position = transform.position;
        hero.SetActive(true);
        StartCoroutine(SpawnChaser());
    }
    private IEnumerator SpawnChaser()
    {
        yield return new WaitForSeconds(3);
        GameObject chaser = Instantiate(Chaser);
        chaser.transform.position = transform.position;
        chaser.SetActive(true);
        gameObject.SetActive(false);
    }

}
