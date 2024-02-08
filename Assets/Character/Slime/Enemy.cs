using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Default initialize values")]
    public Stats initial_max_health;
    public Stats initial_damage;
    public Stats initial_moveSpeed;

    private int max_health { get; set; }
    private int damage { get; set; }
    private float moveSpeed { get; set; }
    //public Stats armor;
    public Stats initial_exp;
    private int exp { get; set; }
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
                rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime);
            }       
        }
    }

    private void Start() {
        max_health = initial_max_health.GetValue();
        damage = initial_damage.GetValue();
        moveSpeed = initial_moveSpeed.GetValue();
        exp = initial_exp.GetValue();

        currentHealth = max_health;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public void ResetToInitialStats()
    {
        SetAttributes(
            initial_max_health.GetValue(),
            initial_damage.GetValue(),
            initial_moveSpeed.GetValue(),
            initial_exp.GetValue()
        );
    }

    public void TakeDamage (int damage) {
        // damage -= armor.GetValue();
        // damage = Mathf.Clamp(damage, 0, int.MaxValue);

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
            playerStats.AddExp(exp);
        }
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    public void FreezeEnemy() {
        canMove = false;
    }

    public void SetAttributes(int max_health, int damage, float moveSpeed, int exp) {
        //Debug.Log("Setting attributes: " + max_health + ", " + damage + ", " + moveSpeed + ", " + exp);
        this.max_health = max_health;
        currentHealth = max_health;
        this.damage = damage;
        this.moveSpeed = moveSpeed;
        this.exp = exp;
        //Debug.Log("New attributes: " + this.max_health + ", " + this.damage + ", " + this.moveSpeed + ", " + this.exp);
    }

    public int GetMaxHealth() {
        return max_health;
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
