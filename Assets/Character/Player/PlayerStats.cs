using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 3;
    public float damage = 1;

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

    Animator animator;
    Rigidbody2D rb;
    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Die() {
        animator.SetTrigger("Die");
    }

    public void RemovePlayer() {
        Destroy(gameObject);
    }
}
