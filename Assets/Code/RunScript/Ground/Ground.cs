using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int current_level;
    [SerializeField] private float Height;
    private Collider2D collider2d;
    private float width;
    private void OnEnable()
    {
        int update_level = GameManager.instance.Get_current_level();
        if (current_level != update_level)
        {
            current_level = update_level;
            moveSpeed = GameManager.instance.Get_ground_movespeed(current_level);
        }
        GameManager.instance.onLevelChange += OnLevelChange;
        IsPlayerCollision = false;
        Generate_Coins();
        Generate_Obstacles();
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
            GameObject coin = CoinPool.instance.GetNewObjects();
            coin.transform.SetParent(transform, false);
            coin.transform.position = transform.position + CoinPosition + new Vector3(i * 0.5f , 0);
            coin.SetActive(true);
        }
    }
    private void Generate_Obstacles()
    {
        GameObject obstacle = ObstaclePool.instance.GetNewObjects();
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
            Height = Random.Range(-5f, 0.5f);
        }
    }
    void Update()
    {
        gameObject.transform.position -= new Vector3( moveSpeed * Time.deltaTime,0);
        if( transform.position.y != Height)
        {
            gameObject.transform.position += new Vector3(0,(Height-transform.position.y)* 1f * Time.deltaTime);
        }
        if( gameObject.transform.position.x <= resetPosition.transform.position.x)
        {
            Grounds_Pool.instance.Add_Grounds(gameObject);
            gameObject.SetActive(false);
        }
    }
}
