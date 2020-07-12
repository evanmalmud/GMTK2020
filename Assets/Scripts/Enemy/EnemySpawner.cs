using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public AttemptToSpawn[] spawnPoints;
    public GameObject enemy;
    public GameObject boss;
    public GameObject player;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;

    public float easyModeEnd = 30f;
    public float mediumModeEnd = 60f;
    public float hardModeEnd = 200f;
    public float insaneModeEnd = 500f;

    public GameObject mediumBounce;
    public GameObject hardMagnets;
    public GameObject insaneSpikes;

    public FadeInGameOVer gameOver;

    public float timer = 0f;

    private bool easy = false, med = false, hard = false, insane = false;
    // Use this for initialization
    void Start()
    {
        startEasyMode();
        easy = true;
    }

    private void Update()
    {
        if(timer >= insaneModeEnd) {
            gameOver.specialGameOver();
        }
        if(timer >= hardModeEnd && hard == true && insane == false) {
            CancelInvoke();
            startInsaneMode();
            insane = true;
            hard = false;
        } else if (timer >= mediumModeEnd && med == true && hard == false) {
            CancelInvoke();
            startHardMode();
            hard = true;
            med = false;
        }
        else if (timer >= easyModeEnd && easy == true && med == false)
        {
            CancelInvoke();
            startMediumMode();
            med = true;
            easy = false;
        }

        timer += Time.deltaTime;
    }

    void addEnemy()
    {
        // Instantiate a random enemy.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        bool result = spawnPoints[spawnPointIndex].attemptToSpawnEnemy(enemy, player);
        if(!result) {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            spawnPoints[spawnPointIndex].attemptToSpawnEnemy(enemy, player);
        }
    }

    void addBoss()
    {
        // Instantiate a random enemy.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        bool result = spawnPoints[spawnPointIndex].attemptToSpawnEnemy(boss, player);
        if (!result)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            spawnPoints[spawnPointIndex].attemptToSpawnEnemy(boss, player);
        }
    }

    void startEasyMode()
    {
        Debug.Log("East Mode Start");
        InvokeRepeating("addEnemy", 5, 2);
    }

    void startMediumMode()
    {
        Debug.Log("Medium Mode Start");
        InvokeRepeating("addEnemy", 5, 1);
        mediumBounce.SetActive(true);
    }

    void startHardMode()
    {
        Debug.Log("Hard Mode Start");
        InvokeRepeating("addEnemy", 5, 1);
        InvokeRepeating("addBoss", 5, 2);
        hardMagnets.SetActive(true);
        mediumBounce.SetActive(false);
    }

    void startInsaneMode()
    {
        Debug.Log("Insane Mode Start");
        InvokeRepeating("addBoss", 5, 0.5f);
        hardMagnets.SetActive(false);
        insaneSpikes.SetActive(true);
    }
}
