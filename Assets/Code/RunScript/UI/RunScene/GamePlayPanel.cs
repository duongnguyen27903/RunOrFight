using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayPanel : MonoBehaviour
{
    private PlayerRun player;
    private void Start()
    {
        player = FindObjectOfType<PlayerRun>();
    }
    public void ActiveFire()
    {
        player.ActiveFire();
    }
    public void ActiveIce()
    {
        player.ActiveIce();
    }
    public void FightScene()
    {
        SceneManager.LoadScene("FightScene");
    }
    public void Pause_Press()
    {
        GameManager.Instance.SetGameState(GameManager.GameState.Pause);
    }
    
}
