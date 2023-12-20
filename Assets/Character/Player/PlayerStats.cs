using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 3;
    public float damage = 1;

    public float moveSpeed = 700f;
    
    public float maxSpeed = 2f;

    public int level = 1;
    private double currentExp = 0;

    private double expToNextLevel = 0; 

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
        CalculateExpToNextLevel();
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
}
