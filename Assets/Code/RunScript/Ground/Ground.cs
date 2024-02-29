using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private float moveSpeed;
    private int current_level;
    private float Height;
    private Collider2D collider2d;
    private float width;
    private readonly List<string> obstacle_tags = new() { "IceObstacle","FireObstacle","Rock"};
    private void OnEnable()
    {
        int update_level = GameManager.Instance.Get_current_level();
        if (current_level != update_level)
        {
            current_level = update_level;
            moveSpeed = GameManager.Instance.Get_ground_movespeed(current_level);
        }
        GameManager.Instance.onLevelChange += OnLevelChange;
        IsPlayerCollision = false;
        if (SpawnGround.Instance.AllowToSpawn == true)
        {
            Generate_Coins();
            Generate_Obstacles();
        }
    }
    private void OnDisable()
    {
        IsPlayerCollision = false;
        current_level = 0;
        moveSpeed = 0;
    }

    private void Generate_Coins()
    {
        int x = Random.Range(3, 6);
        Vector3 CoinPosition = new(Random.Range(0, width - x), Random.Range(1f, 3f));
        for (int i = 0; i < x; i++)
        {
            GameObject coin = CoinPool.Instance.GetNewObjects("Coin");
            coin.transform.SetParent(transform, false);
            coin.transform.position = transform.position + CoinPosition + new Vector3(i * 0.5f , 0);
            coin.SetActive(true);
        }
    }
    private void Generate_Obstacles()
    {
        GameObject obstacle = ObstaclePool.Instance.GetNewObjects(obstacle_tags[Random.Range(0,obstacle_tags.Count)]);
        obstacle.transform.SetParent(transform, false);
        obstacle.transform.position = transform.position + new Vector3(Random.Range(0, width-1), 1);
        obstacle.SetActive(true);
    }
    private void OnLevelChange(Level level, int currentLevel)
    {
        current_level = currentLevel;
        moveSpeed = level.MoveSpeed;
    }

    private Transform resetPosition;
    private void Awake()
    {
        resetPosition = GameObject.Find("ResetPosition").transform;
        collider2d = gameObject.GetComponent<Collider2D>();
        width = collider2d.bounds.size.x;
    }
    //kiem tra xem player da cham lan dau chua
    private bool IsPlayerCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayerCollision == true) return;
        if( collision.gameObject.CompareTag("Player") )
        {
            IsPlayerCollision = true;
            if(Random.Range(0, 2) == 1 && SpawnGround.Instance.AllowToSpawn == true) Height = Random.Range(-5f, 0.5f) ;
        }
    }
    void Update()
    {
        gameObject.transform.position -= new Vector3( moveSpeed * Time.deltaTime,0);
        //if( transform.position.y != Height && Random.Range(0, 2) == 1 && SpawnGround.Instance.AllowToSpawn == true)
        //{
        //    transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x, Height),1);
        //}
        if( gameObject.transform.position.x <= resetPosition.transform.position.x)
        {
            Grounds_Pool.Instance.Add_Grounds(gameObject);
            gameObject.SetActive(false);
        }
    }
}
