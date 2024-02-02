using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Achivement : WindowUIBase
{
    [SerializeField] private TextMeshProUGUI HighestScore;

    private void OnEnable()
    {
        int highest_score = PlayerPrefs.GetInt("highest_score", 0);
        HighestScore.text = "Highest Score : " + highest_score.ToString();
    }
}
