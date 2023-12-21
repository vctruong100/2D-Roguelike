using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public float health = 1;
    public float damage = 1;

    public float moveSpeed = 50f;

    public float knockbackForce = 300f;
    Rigidbody2D rb;

    public Detection detection;

    bool canMove = true;

    public PlayerStats playerStats;

    void FixedUpdate() {
        if(canMove) {
            if(detection.detectedObjects.Count > 0) {
                Collider2D target = detection.detectedObjects[0];
                Vector2 direction = (target.transform.position - transform.position).normalized;
                rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime);
            }       
        }
    }

    public void AddHealth(float amount) {
        health += amount;
    }

    public void AddDamage(float amount) {
        damage += amount;
    }

    public void addMoveSpeed(float amount) {
        moveSpeed += amount;
    }

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public float Health {
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
        playerStats.AddExp(100);
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    public void FreezeEnemy() {
        canMove = false;
    }

}
