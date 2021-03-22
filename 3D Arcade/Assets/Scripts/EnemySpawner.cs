using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float xRange = 1f;
    public float yRange = 1f;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        float xOffset = Random.Range(-xRange, xRange);
        float yOffset = Random.Range(-yRange, yRange);
        int spawnEnemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[spawnEnemyIndex], transform.position + new Vector3(xOffset, yOffset, 0), enemies[spawnEnemyIndex].transform.rotation);
        Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
