using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject enemy;
    public GameObject player;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("addEnemy", spawnDelay, spawnTime);

    }

    void addEnemy()
    {
        // Instantiate a random enemy.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject enemyGO = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemyGO.GetComponent<AIDestinationSetter>().target = player.transform;
    }
}
