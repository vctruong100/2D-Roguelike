using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 10;

    void Start()
    {
        // Spawn enemies when the scene starts
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
