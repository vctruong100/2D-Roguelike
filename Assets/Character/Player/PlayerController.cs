using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    Rigidbody2D rb;

    Vector2 movementInput;

    public ContactFilter2D movementFilter;
    public float collisionOffset = 1f;

    Animator animator;

    SpriteRenderer spriteRenderer;

    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() { //Certain physics calculations are done in fixed update
        
        if (movementInput != Vector2.zero) {
            bool success = TryMove(movementInput);

            if (!success) {
                success = TryMove(new Vector2(movementInput.x, 0));
            }

            if (!success) {
                success = TryMove(new Vector2(0, movementInput.y));
            }

            animator.SetBool("isMoving", success);
        }
        else {
            animator.SetBool("isMoving", false);
        }
        if (movementInput.x < 0) {
            spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0) {
            spriteRenderer.flipX = false;
        }

        UpdateAnimatorParameters();
    }

    private bool TryMove(Vector2 direction) {
        if (direction != Vector2.zero) {
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollision,
                moveSpeed * Time.fixedDeltaTime * collisionOffset);

            if (count == 0) {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
            return false;
            }
        }
        return false;
    }
    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
    void OnFire() {
        animator.SetTrigger("swordAttack");
    }

    void UpdateAnimatorParameters() {
        animator.SetFloat("xInput", movementInput.x);
        animator.SetFloat("yInput", movementInput.y);
    }
}
