using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] public float timeBetweenSpawns = 5F;
    private float timeSinceLastSpawn;

    [SerializeField] private EnemyAI Enemy;
    private IObjectPool<EnemyAI> enemyPool;

    private void Awake()
    {
        enemyPool = new ObjectPool<EnemyAI>(CreateEnemy);
    }

    private EnemyAI CreateEnemy()
    {
        EnemyAI enemy = Instantiate(Enemy);
        return enemy;

    }
    void Start()
    {
        timeSinceLastSpawn = Time.time + timeBetweenSpawns;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > timeSinceLastSpawn)
        {
            SpawnGhosts();
            timeSinceLastSpawn = Time.time + timeBetweenSpawns;
        }
    }

    private void SpawnGhosts()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.Log("nothing");
        }

        EnemyAI enemy = enemyPool.Get();

        int indexSpot = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawn = spawnPoints[indexSpot];
        enemy.transform.position = selectedSpawn.position;
        enemy.transform.rotation = selectedSpawn.rotation;

        enemy.gameObject.SetActive(true);
    }
}
