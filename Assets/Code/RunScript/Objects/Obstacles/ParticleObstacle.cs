using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleObstacle : Obstacle
{
    [SerializeField] private ParticleSystem ParticleSystem;
    private void Awake()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
    }

    [System.Obsolete]
    private void OnEnable()
    {
        ParticleSystem.startSpeed = Random.Range(4f, 8f);
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.CompareTag("LeftSideCollider"))
        {
            gameObject.SetActive(false);
        }
    }
}
