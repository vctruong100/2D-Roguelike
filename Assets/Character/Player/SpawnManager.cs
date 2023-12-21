using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 1;
    public float minX = -3.2f;
    public float maxX = 3.4f;
    public float minY = -1.7f;
    public float maxY = 2.2f;
    public float spawnInterval = 20f;

    public MapLevel mapLevel;

    void Start()
    {
        // Spawn enemies when the scene starts
        SpawnEnemiesPeriodically();
    }

    void SpawnEnemiesPeriodically()
    {
        // Call SpawnEnemies every spawnInterval seconds, repeating every spawnInterval seconds
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    void SpawnEnemies()
    {
        // Check if the time interval has passed or if there are no enemies in the scene
        if (Time.time >= spawnInterval || GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                float spawnX = Random.Range(minX, maxX);
                float spawnY = Random.Range(minY, maxY);
                Vector2 spawnPosition = new Vector2(spawnX, spawnY);

                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }

            // Reset the timer
            spawnInterval = Time.time + spawnInterval;
            mapLevel.IncreaseLevel();
            enemyPrefab.GetComponent<Enemy>().AddHealth(mapLevel.currentLevel / 2);
            enemyPrefab.GetComponent<Enemy>().AddDamage(mapLevel.currentLevel / 2);
            enemyPrefab.GetComponent<Enemy>().addMoveSpeed(1);
            if (numberOfEnemies < 10) {
                numberOfEnemies += 1;
            }
        }
    }
}
