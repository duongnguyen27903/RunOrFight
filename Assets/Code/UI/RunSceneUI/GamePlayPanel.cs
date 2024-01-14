using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayPanel : MonoBehaviour
{
    [SerializeField] private GameObject Fire;
    [SerializeField] private GameObject Ice;
    public void ActiveFire()
    {
        Fire.SetActive(true);
        Ice.SetActive(false);
    }
    public void ActiveIce()
    {
        Ice.SetActive(true);
        Fire.SetActive(false);
    }
    public void FightScene()
    {
        SceneManager.LoadScene("FightScene");
    }
    public void Pause_Press()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Pause);
    }
}
