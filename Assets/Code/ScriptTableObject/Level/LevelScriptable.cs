using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObject/CreateNewLevel")]
public class LevelScriptable : ScriptableObject
{
    public Level[] level;

    public int LevelCount
    {
        get
        {
            return level.Length;
        }
    }

    public Level GetLevel( int index)
    {
        return level[index];
    }
}
