using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score;

    private void Start()
    {
        Score.text = "Score : " + GameManager.instance.Get_score().ToString();
    }
    public void Menu_Press()
    {
        SceneManager.LoadScene("Menu");
    }
}
