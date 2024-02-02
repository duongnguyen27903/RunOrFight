using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePausePanel : MonoBehaviour
{
    public void Continue_Press()
    {
        GameManager.Instance.SetGameState(GameManager.GameState.Play);
    }
    public void Menu_Press()
    {
        SceneManager.LoadScene("Menu");
    }
}
