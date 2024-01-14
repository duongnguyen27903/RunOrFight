using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePausePanel : MonoBehaviour
{
    public void Continue_Press()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Play);
    }
    public void Menu_Press()
    {
        SceneManager.LoadScene("Menu");
    }
}
