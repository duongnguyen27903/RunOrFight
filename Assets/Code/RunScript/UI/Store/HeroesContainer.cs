using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Heroes
{
    public List<Hero> heroes;
}

public class HeroesContainer : MonoBehaviour
{
    //sau can chinh sua them, tach thuoc tinh owned va selected ra khoi hero_database
    [SerializeField] private HeroDatabase hero_database;
    [SerializeField] private HeroCard hero_card_prefab;
    [SerializeField] private List<HeroCard> hero_cards;
    public Heroes hero_lists = new();
    private void Start()
    {
        if (PlayerPrefs.GetString("heroes") != "")
        {
            string s = PlayerPrefs.GetString("heroes");
            hero_lists = JsonUtility.FromJson<Heroes>(s);
            for (int i = 0; i < hero_lists.heroes.Count; i++)
            {
                HeroCard hero = Instantiate(hero_card_prefab, transform.position + new Vector3(140, 0) + new Vector3(i * 280, 0), Quaternion.identity, transform);
                hero.Init(hero_lists.heroes[i], i);
                hero_cards.Add(hero);
            }
        }
        else
        {
            for (int i = 0; i < hero_database.Count; i++)
            {
                HeroCard hero = Instantiate(hero_card_prefab, transform.position + new Vector3(140, 0) + new Vector3(i * 280, 0), Quaternion.identity, transform);
                hero.Init(hero_database.characters[i], i);
                hero_cards.Add(hero);
                hero_lists.heroes.Add(hero_database.characters[i]);
            }
            string hero_list_temp = JsonUtility.ToJson(hero_lists);
            PlayerPrefs.SetString("heroes", hero_list_temp);
        }
    }
    public void FindSelectedHero(int current)
    {
        hero_lists.heroes[current].selected = true;
        PlayerPrefs.SetString("heroes", JsonUtility.ToJson(hero_lists));
        for (int i = 0; i < hero_cards.Count ; i++)
        {
            if( i == current ) continue ;
            if (hero_cards[i].Iselected == true)
            {
                hero_cards[i].UnSelectHero();
                hero_lists.heroes[i].selected = false;
                PlayerPrefs.SetString("heroes", JsonUtility.ToJson(hero_lists));
                return;
            }
            
        }
    }
    public void UnlockHero(int current)
    {
        hero_cards[current].owned = true;
        hero_lists.heroes[current].owned = true;
        PlayerPrefs.SetString("heroes",JsonUtility.ToJson(hero_lists));
    }

    
    
}
