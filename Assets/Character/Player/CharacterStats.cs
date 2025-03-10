using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    [Header("Default initialize values")]
    public Stats max_health;
    public Stats armor;
    public Stats damage;
    public float moveSpeed;
    public float maxSpeed;
    public Stats regenRate;
    public Stats regenHp;
    public int points;
    public int level { get; private set; }

    private int currentExp { get; set; }
    private int expToNextLevel { get; set; }
    public int currentHealth { get; private set; }
    Animator animator;
    private bool isPlayerAlive;
    Rigidbody2D rb;

    void Awake () {
        currentHealth = max_health.GetValue();
        level = 0;
        currentExp = 0;
        CalculateExpToNextLevel();
        isPlayerAlive = true;
    }
    public void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(RegenerateHealth());
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            LevelUp();
        }
    }

    public void TakeDamage (int damage) {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0) {
            Die();
        }
        else {
            animator.SetTrigger("Hit");
        }
    }

    private IEnumerator RegenerateHealth()
    {
        while (isPlayerAlive)
        {
            yield return new WaitForSeconds(regenRate.GetValue());

            // Increase current health by 1
            currentHealth = Mathf.Min(max_health.GetValue(), currentHealth + regenHp.GetValue());
        }
    }

    public void Die() {
        isPlayerAlive = false;
        animator.SetTrigger("Die");
    }

    public void CalculateExpToNextLevel() {
        expToNextLevel = (int) (level * 100 * 1.25);

    }

    public void AddExp(int exp) {
        currentExp += exp;
        if(currentExp >= expToNextLevel) {
            LevelUp();
        }
    }

    private void LevelUp() {
        level++;
        points++;
        int excessExp = currentExp - expToNextLevel;
        currentExp = 0; 
        CalculateExpToNextLevel();
        Debug.Log("Level: " + level + " - Current exp: " + currentExp + "/" + expToNextLevel);
        AddExp(excessExp);
    }
}
