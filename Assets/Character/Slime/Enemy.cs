using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public float health = 1;
    public float damage = 1;

    Rigidbody2D rb;

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

// In the Enemy script
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.Health -= damage;
                Debug.Log("Player health: " + player.health);
            }
        }
    }


    public void ApplyKnockbackForce(Vector2 direction, float force) {
        rb.AddForce(direction * force);
    }

    public void Die() {
        animator.SetTrigger("Die");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

}
