using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class GameManager : MonoBehaviour
{
    //khai bao mot singleton class
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
    
    //he thong score va checkpoint
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private LevelScriptable levels;
    private int score;
    private int current_level;
    public Action<Level,int> onLevelChange;
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
    private void UpdateLevel()
    {
        for (int i = 1; i < levels.LevelCount; i++)
        {
            if (levels.GetLevel(i).Checkpoint == score)
            {
                current_level++;
                onLevelChange(levels.GetLevel(current_level),current_level);
                Debug.Log($"level : {current_level}");
            }
        }
    }
    private void InitAtStart()
    {
        score = 0;
        current_level = 0;
        onLevelChange(levels.GetLevel(current_level), current_level);
        Score.text = $"Score : {score}";
    }
    void Start()
    {
        InitAtStart();
    }
    private void Update()
    {
        UpdateScore();
        UpdateLevel();
    }

}
