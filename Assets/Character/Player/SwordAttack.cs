using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public enum AttackDirection {
        Left,
        Right
    }

    public AttackDirection attackDirection;

    public float damage = 1;

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
            }
        }
    }

    public void Attack() {
        switch(attackDirection) {
            case AttackDirection.Left:
                AttackLeft();
                break;
            case AttackDirection.Right:
                AttackRight();
                break;
        }
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = AttackOffset;
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-AttackOffset.x, AttackOffset.y);
    }
    
    public void StopAttack() {
        swordCollider.enabled = false;

    }
}
