using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int damage = 1;

    public float knockbackForce = 1000f;
    Vector2 AttackOffset;
    public Collider2D swordCollider;

    private void Start() {
        AttackOffset = transform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            if (other.transform.parent != null)
            {
                Enemy enemy = other.transform.parent.GetComponent<Enemy>();
                if (enemy != null) {
                    enemy.TakeDamage(damage);
                    Debug.Log("Enemy health: " + enemy.currentHealth);
                    ApplyKnockback(enemy);
                }
            }
        }
    }

    private void ApplyKnockback(Enemy enemy)
    {
        Vector2 knockbackDirection = (Vector2) (enemy.transform.position - transform.position).normalized;
        enemy.ApplyKnockbackForce(knockbackDirection, knockbackForce);
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = AttackOffset;
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-AttackOffset.x - 0.10f, AttackOffset.y);
    }

    public void AttackUp() {    
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-AttackOffset.x / 2f, -AttackOffset.y + 0.093f);
    }
    
    public void AttackDown() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-AttackOffset.x / 2f, AttackOffset.y - 0.171f);
    }
    
    public void StopAttack() {
        swordCollider.enabled = false;

    }
}
