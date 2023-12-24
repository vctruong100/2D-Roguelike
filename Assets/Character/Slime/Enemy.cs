using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Default initialize values")]
    public Stats max_health;
    public Stats damage;
    public Stats moveSpeed;
    public Stats exp;
    public float knockbackForce = 300f;
    public int currentHealth { get; private set; }
    Animator animator;
    Rigidbody2D rb;

    public Detection detection;
    bool canMove = true;

    PlayerStats playerStats;

    void FixedUpdate() {
        if(canMove) {
            if(detection.detectedObjects.Count > 0) {
                Collider2D target = detection.detectedObjects[0];
                Vector2 direction = (target.transform.position - transform.position).normalized;
                rb.AddForce(direction * moveSpeed.GetValue() * Time.fixedDeltaTime);
            }       
        }
    }

    private void Start() {
        currentHealth = max_health.GetValue();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public void TakeDamage (int damage) {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0) {
            Die();
        }
        else {
            animator.SetTrigger("Hit");
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
            playerStats.AddExp(exp.GetValue());
        }
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    public void FreezeEnemy() {
        canMove = false;
    }
}
