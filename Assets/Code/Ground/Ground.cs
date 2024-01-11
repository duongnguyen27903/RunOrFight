using Unity.VisualScripting;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int current_level;
    [SerializeField] private float Height;
    private void OnEnable()
    {
        int update_level = GameManager.instance.Get_current_level();
        if (current_level != update_level)
        {
            current_level = update_level;
            moveSpeed = GameManager.instance.Get_ground_movespeed(current_level);
        }
        Debug.Log($"current level : {current_level}, movespeed : {moveSpeed} ");
        GameManager.instance.onLevelChange += OnLevelChange;
        Height = Random.Range(-5f, 1.5f);
    }

    private void OnLevelChange(Level level, int currentLevel)
    {
        current_level = currentLevel;
        moveSpeed = level.MoveSpeed;
        Debug.Log($"current level : {current_level}, movespeed : {moveSpeed} ");
    }

    private Transform resetPosition;
    private void Start()
    {
        resetPosition = GameObject.Find("ResetPosition").transform;
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
