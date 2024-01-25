using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private PlayerRun player;
    private void OnEnable()
    {
        player = FindObjectOfType<PlayerRun>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftSideCollider"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("PlayerRadar") && player.Get_Player_Power() == Player.Power.fire)
        {
            gameObject.SetActive(false);
            GameObject power_burst = PowerBurstPool.instance.Get_New_FireBurst();
            power_burst.transform.position = collision.transform.position;
            power_burst.SetActive(true);
        }
    }
    
    private void OnParticleCollision(GameObject other)
    {
        if( other.CompareTag("Player"))
        {
            if(player.Get_Player_Power() != Player.Power.fire)
            {
                GameManager.instance.SetGameState(GameManager.GameState.GameOver);
            }
        }
    }
}
