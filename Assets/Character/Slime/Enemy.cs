using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public float health = 1;
    public float damage = 1;

    public float moveSpeed = 500f;

    public float knockbackForce = 300f;
    Rigidbody2D rb;

    public Detection detection;

    void FixedUpdate() {
        if(detection.detectedObjects.Count > 0) {
            Collider2D target = detection.detectedObjects[0];
            Vector2 direction = (target.transform.position - transform.position).normalized;
            rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime);
        }
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
        rb.AddForce(direction * force);
    }

    public void ApplyKnockback(PlayerController player)
    {
        Vector2 knockbackDirection = (Vector2) (player.transform.position - transform.position).normalized;
        player.ApplyKnockbackForce(knockbackDirection, knockbackForce);
    }

    public void Die() {
        animator.SetTrigger("Die");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

}
