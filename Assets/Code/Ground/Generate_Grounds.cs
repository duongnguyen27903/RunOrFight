using UnityEngine;

public class Generate_Grounds : MonoBehaviour
{
    [SerializeField] private float DISTANCE_TO_GENERATE;
    [SerializeField] private Transform Generate_Ground_Position;
    [SerializeField] private Vector3 GenerateDistance;
    private GameObject ground;

    private void OnEnable()
    {
        GameManager.instance.onLevelChange += OnLevelChange;
        
    }
    //private void OnDisable()
    //{
    //    GameManager.instance.onLevelChange -= OnLevelChange;
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
        if( Generate_Ground_Position.position.x - GenerateDistance.x > DISTANCE_TO_GENERATE)
        {
            ground = Grounds_Pool.instance.Get_new_ground();
            //ground.transform.position = Generate_Ground_Position.transform.position;
            ground.transform.position = new Vector3(Generate_Ground_Position.transform.position.x,Random.Range(-5f,1.5f));
            GenerateDistance = ground.transform.Find("RightTop").position;
            ground.SetActive(true);
        }
    }
}
