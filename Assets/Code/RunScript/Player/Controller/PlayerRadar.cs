using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRada : MonoBehaviour
{
    [SerializeField] private Player.Power power;
    private PlayerRun player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerRun>();
    }
    private void OnEnable()
    {
        player.onChangePower += OnChangePower;
    }
    private void OnChangePower(Player.Power current_power)
    {
        power = current_power;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("IceObstacle") && power == Player.Power.fire)
        {
            collision.gameObject.SetActive(false);
            GameObject power_burst = PowerBurstPool.Instance.Get_New_FireBurst();
            power_burst.transform.position = transform.position;
            power_burst.SetActive(true);
        }
    }
}
