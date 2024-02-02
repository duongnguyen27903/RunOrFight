using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1)]
public class SpawnGround : MonoBehaviour
{
    private static SpawnGround instance;
    public static SpawnGround Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SpawnGround>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] private float DISTANCE_TO_GENERATE;
    [SerializeField] private Transform Generate_Ground_Position;
    [SerializeField] private Vector3 GenerateDistance;
    [SerializeField] private float BootTime;
    [SerializeField] private bool allowToSpawn;
    public bool AllowToSpawn { get { return allowToSpawn; }  }
    [SerializeField] private List<string> GroundTag = new() { "LongGround","NormalGround","ShortGround"};
    private GameObject ground;
    
    private void OnEnable()
    {
        GameManager.Instance.onLevelChange += OnLevelChange;
        
    }
    //private void OnDisable()
    //{
    //    GameManager.Instance.onLevelChange -= OnLevelChange;
    //}
    private void OnLevelChange(Level level, int current_level)
    {
        DISTANCE_TO_GENERATE = level.MAX_DISTANCE;
    }
    void Start()
    {
        ground = GameObject.Find("LongGround");
        GenerateDistance = ground.transform.Find("RightTop").position;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(GenerateDistance, 0.5f);
    }
    void Update()
    {
        GenerateDistance = ground.transform.Find("RightTop").position;
        if ( BootTime > 0f )
        {
            if(Generate_Ground_Position.position.x - GenerateDistance.x > 0)
            {
                ground = Grounds_Pool.Instance.Get_new_ground(GroundTag[0]);
                ground.transform.position = GenerateDistance;
                GenerateDistance = ground.transform.Find("RightTop").position;
                ground.SetActive(true);
            }
            BootTime -= Time.deltaTime;
        }
        else
        {
            allowToSpawn = true;
            if (Generate_Ground_Position.position.x - GenerateDistance.x > DISTANCE_TO_GENERATE)
            {
                ground = Grounds_Pool.Instance.Get_new_ground(GroundTag[Random.Range(0, GroundTag.Count)]);
                ground.transform.position = new Vector3(Generate_Ground_Position.transform.position.x, Random.Range(-5f, 0.5f));
                GenerateDistance = ground.transform.Find("RightTop").position;
                ground.SetActive(true);
            }
        }
        
    }
}
