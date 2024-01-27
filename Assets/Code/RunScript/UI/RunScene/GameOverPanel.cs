using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI Coins;

    private void UpdateHighestScore()
    {
        int highestScore = PlayerPrefs.GetInt("highest_score",0);
        int current_score = GameManager.instance.Get_score();
        if ( highestScore < current_score )
        {
            PlayerPrefs.SetInt("highest_score", current_score);
        }
    }
    private void UpdateCoinsCollected()
    {
        int current_coins = PlayerPrefs.GetInt("Coins",0);
        PlayerPrefs.SetInt("Coins", current_coins + GameManager.instance.Get_Coins_Collected());
    }
    private void Start()
    {
        Score.text = "Score : " + GameManager.instance.Get_score().ToString();
        Coins.text = "Coins : " + GameManager.instance.Get_Coins_Collected().ToString();
        UpdateHighestScore();
        UpdateCoinsCollected();
    }
    public void Menu_Press()
    {
        SceneManager.LoadScene("Menu");
    }
}
