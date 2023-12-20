using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 1;

    public float knockbackForce = 1000f;
    Vector2 AttackOffset;
    public Collider2D swordCollider;

    private void Start() {
        AttackOffset = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null) {
                enemy.Health -= damage;
                ApplyKnockback(enemy);
            }
        }
    }

    private void ApplyKnockback(Enemy enemy)
    {
        Vector2 knockbackDirection = (Vector2) (enemy.transform.position - transform.position).normalized;
        enemy.ApplyKnockbackForce(knockbackDirection, knockbackForce);
    }

    public void AttackRight() {
        Debug.Log("Attacking right");
        swordCollider.enabled = true;
        transform.localPosition = AttackOffset;
    }

    public void AttackLeft() {
        Debug.Log("Attacking left");
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-AttackOffset.x, AttackOffset.y);
    }
    
    public void StopAttack() {
        swordCollider.enabled = false;

    }
}
