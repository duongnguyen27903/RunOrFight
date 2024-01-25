using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "ScriptableObject/Hero", order = 1 )]
public class HeroDatabase : ScriptableObject
{
    public Hero[] characters;

    public int Count { 
        get
        {
            return characters.Length;
        }
    }

    public Hero GetHero( int index )
    {
        return characters[index];
    }
}

