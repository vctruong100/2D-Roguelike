using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public int numberOfEnemies = 1;
    public float minX = -3.2f;
    public float maxX = 3.4f;
    public float minY = -1.7f;
    public float maxY = 2.2f;
    public float spawnInterval = 10f;

    MapLevel mapLevel;
    List<GameObject> spawnedEnemies = new List<GameObject>(); // Keep track of spawned enemies

    void Start()
    {
        mapLevel = FindObjectOfType<MapLevel>();
        SpawnEnemiesPeriodically();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            mapLevel.IncreaseLevel();
        }
    }

    void SpawnEnemiesPeriodically()
    {
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    void SpawnEnemies()
    {
        if (Time.time >= spawnInterval || spawnedEnemies.Count == 0)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                float spawnX = Random.Range(minX, maxX);
                float spawnY = Random.Range(minY, maxY);
                Vector2 spawnPosition = new Vector2(spawnX, spawnY);

                if (enemies.Count > 0)
                {
                    GameObject enemyGO = Instantiate(enemies[0], spawnPosition, Quaternion.identity);
                    spawnedEnemies.Add(enemyGO); // Keep a reference to the spawned enemy
                    Enemy enemy = enemyGO.GetComponent<Enemy>();

                    // Modify attributes with a slight delay
                    StartCoroutine(ModifyEnemyAttributesDelayed(enemy));
                }
            }

            spawnInterval = Time.time + spawnInterval;
            mapLevel.IncreaseLevel();

            int current = mapLevel.currentLevel;
            if (current == 15 || current == 30 || current == 51 || current == 75 || current == 101)
            {
                enemies.RemoveAt(0);
            }

            if (current == 15 || current == 30 || current == 51 || current == 75 || current == 101)
            {
                numberOfEnemies = 1;
            }

            if (numberOfEnemies < 30)
            {
                numberOfEnemies += 1;
            }
        }
    }

    IEnumerator ModifyEnemyAttributesDelayed(Enemy enemy)
    {
        // Wait for a short delay (adjust this as needed)
        yield return new WaitForSeconds(0.1f);

        int levelMultiplier = mapLevel.currentLevel;
        int new_hp = enemy.initial_max_health.GetValue() + levelMultiplier * 2;
        int new_damage = enemy.initial_damage.GetValue() + levelMultiplier / 2;
        float new_speed = enemy.initial_moveSpeed.GetValue();
        if (new_speed < 70)
        {
            new_speed = enemy.initial_moveSpeed.GetValue() + levelMultiplier / 2;
        }
        else
        {
            new_speed = 70f;
        }
        int new_exp = enemy.initial_exp.GetValue() + 50 * levelMultiplier;

        Debug.Log("Enemy: " + enemy.name);
        Debug.Log("Before Enemy Attributes: Health: " + enemy.GetMaxHealth() + " Damage: " + enemy.GetDamage() + " Speed: " + enemy.GetMoveSpeed() + " Exp: " + enemy.GetExp());
        enemy.SetAttributes(new_hp, new_damage, new_speed, new_exp);
        Debug.Log("After Enemy Attributes: Health: " + enemy.GetMaxHealth() + " Damage: " + enemy.GetDamage() + " Speed: " + enemy.GetMoveSpeed() + " Exp: " + enemy.GetExp());
    }

}
