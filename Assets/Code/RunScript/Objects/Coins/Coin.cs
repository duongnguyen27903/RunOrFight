using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.CompareTag("Player") ) 
        {
            gameObject.SetActive(false);
            GameManager.Instance.Update_Coins_Collected(1);
        }
        if (collision.gameObject.CompareTag("LeftSideCollider"))
        {
            gameObject.SetActive(false);
        }
    }
}
