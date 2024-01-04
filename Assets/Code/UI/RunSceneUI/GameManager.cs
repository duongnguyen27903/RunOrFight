using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    public static GameManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<GameManager>();
            }
            return Instance;
        }
    }
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private LevelScriptable levels;
    private int score;
    private int current_level;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        score = 0;
        current_level = 0;
        Score.text = $"Score : { score }";
    }
    private void Update()
    {
        UpdateScore();
        for( int i=1; i<levels.LevelCount; i++ )
        {
            if(levels.GetLevel(i).Checkpoint == score)
            {
                current_level++;
                Debug.Log($"level : {current_level}");
            }
        }
    }

    public float Get_ground_movespeed(int current_level)
    {
        float movespeed = levels.GetLevel(current_level).MoveSpeed;
        return movespeed;
    }

    public int Get_current_level()
    {
        return current_level;
    }


    public void UpdateScore()
    {
        if( Time.timeScale != 0)
        {
            score += 1;
        }
        Score.text = $"Score : {score}";
    }
}
