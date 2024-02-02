using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class GameManager : MonoBehaviour
{
    //khai bao mot singleton class
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //quan ly game state
    public enum GameState
    {
        Play,
        Pause,
        GameOver
    }
    [SerializeField] private GameObject PlayPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject GameOverPanel;
    private GameState game_state;
    public void SetGameState( GameState state )
    {
        game_state = state;
        PlayPanel.SetActive( game_state == GameState.Play );
        PausePanel.SetActive( game_state == GameState.Pause );
        GameOverPanel.SetActive( game_state == GameState.GameOver );
        if (game_state == GameState.Pause || game_state == GameState.GameOver )
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1f;
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
    public int Get_score()
    {
        return score;
    }
    private void Init()
    {
        current_level = 0;
        score = 0;
        Score.text = $"Score : {score}";
        coins_collected = 0;
        Coins_Collected.text = $"{coins_collected}";
        onLevelChange(levels.GetLevel(current_level), current_level);
        SetGameState(GameState.Play);
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
            }
        }
    }

    //quan ly so coin thu thap duoc trong moi lan choi
    [SerializeField] private int coins_collected;
    [SerializeField] private TextMeshProUGUI Coins_Collected;
    public void Update_Coins_Collected( int coin )
    {
        coins_collected += coin;
        Coins_Collected.text = $"{coins_collected}";
    }
    public int Get_Coins_Collected()
    {
        return coins_collected;
    }

    void Start()
    {
        Init();
    }
    private void Update()
    {
        UpdateScore();
        UpdateLevel();
    }

}
