using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyInitialStats initialStats;
    private int health;
    private int damage;
    private float moveSpeed;
    private int exp;
    Animator animator;

    public float knockbackForce = 300f;
    Rigidbody2D rb;

    public Detection detection;


    bool canMove = true;

    PlayerStats playerStats;

    void FixedUpdate() {
        if(canMove) {
            if(detection.detectedObjects.Count > 0) {
                Collider2D target = detection.detectedObjects[0];
                Vector2 direction = (target.transform.position - transform.position).normalized;
                rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime);
            }       
        }
    }

    public void AddHealth(int amount) {
        health += amount;
    }

    public void AddDamage(int amount) {
        damage += amount;
    }

    public void addMoveSpeed(float amount) {
        moveSpeed += amount;
    }

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ResetStats();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public int Health {
        set {
            health = value;
            if(health <= 0) {
                Die();
            }
            else {
                animator.SetTrigger("Hit");
            }
        }
        get {
            return health;
        }
    }

    public void ApplyKnockbackForce(Vector2 direction, float force) {
        if (canMove) {
            rb.AddForce(direction * force);
        }
    }

    public void ApplyKnockback(PlayerController player)
    {
        Vector2 knockbackDirection = (Vector2) (player.transform.position - transform.position).normalized;
        player.ApplyKnockbackForce(knockbackDirection, knockbackForce);
    }

    public void Die() {
        animator.SetTrigger("Die");
        if (playerStats != null) {
            playerStats.AddExp(exp);
        }
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    public void FreezeEnemy() {
        canMove = false;
    }

    private void ResetStats()
    {
        health = initialStats.initial_health;
        damage = initialStats.initial_damage;
        moveSpeed = initialStats.initial_moveSpeed;
        exp = initialStats.initial_exp;
    }

    public int GetHealth() {
        return health;
    }

    public int GetDamage() {
        return damage;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public int GetExp() {
        return exp;
    }
}
