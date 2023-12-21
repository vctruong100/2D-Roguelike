using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 3;

    private float currentHealth;
    public float damage = 1;

    public float moveSpeed = 700f;

    public float regenRate = 5f;

    public float regenHp = 1f;
    
    public float maxSpeed = 2f;

    public int level = 1;
    private double currentExp = 0;

    private double expToNextLevel = 0; 

    public float Health {
        set {
            currentHealth = value;
            if(currentHealth <= 0) {
                Die();
            }
            else {
                animator.SetTrigger("Hit");
            }
        }
        get {
            return currentHealth;
        }
    }

    Animator animator;
    Rigidbody2D rb;
    private void Start() {
        currentHealth = health;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        CalculateExpToNextLevel();

        StartCoroutine(RegenerateHealth());
    }

    private IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenRate);

            // Increase current health by 1
            currentHealth = Mathf.Min(health, currentHealth + regenHp);
            Debug.Log("Current health: " + currentHealth);
        }
    }

    public void Die() {
        animator.SetTrigger("Die");
    }

    public void CalculateExpToNextLevel() {
        expToNextLevel = 100.0 * level * level * 0.8;
    }

    public void AddExp(int exp) {
        currentExp += exp;
        if(currentExp >= expToNextLevel) {
            LevelUp();
        }
    }

    private void LevelUp() {
        level++;
        currentExp = currentExp - expToNextLevel;
        CalculateExpToNextLevel();
    }

    public void RemovePlayer() {
        Destroy(gameObject);
    }

    public string GetLevel() {
        return level.ToString();
    }

    public string GetHealth() {
        return health.ToString();
    }
    
    public string GetCurrentHealth() {
        return currentHealth.ToString();
    }
    public string GetDamage() {
        return damage.ToString();
    }

    public string GetMoveSpeed() {
        return moveSpeed.ToString();
    }

    public string GetExp() {
        return currentExp.ToString();
    }
}
