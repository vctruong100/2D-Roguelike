using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float idleFriction = 0.9f;

    Rigidbody2D rb;

    Vector2 moveInput = Vector2.zero;
    Vector2 lastNonZeroMovement;

    Animator animator;
    SpriteRenderer spriteRenderer;
    bool canMove = true;
    private bool isMoving = false;
    public SwordAttack swordAttack;

    PlayerStats playerStats;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerStats = GetComponent<PlayerStats>();

    }


    void FixedUpdate() {
        if (canMove) {
            if(moveInput != Vector2.zero) {
                rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * playerStats.moveSpeed * Time.deltaTime), playerStats.maxSpeed);
                animator.SetBool("isMoving", true);
                if(moveInput.x > 0) {
                    spriteRenderer.flipX = false;
                } else if (moveInput.x < 0) {
                    spriteRenderer.flipX = true;
                }
                lastNonZeroMovement = moveInput;
                UpdateAnimatorParameters();

        } else {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            animator.SetBool("isMoving", false);
        }
        }
    }


    public bool IsMoving {
        set{
            isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    void UpdateAnimatorParameters()
    {
        animator.SetFloat("xInput", moveInput.x);
        animator.SetFloat("yInput", moveInput.y);
        animator.SetFloat("lastXInput", lastNonZeroMovement.x);
        animator.SetFloat("lastYInput", lastNonZeroMovement.y);
    }

    public void ApplyKnockbackForce(Vector2 direction, float force) {
        rb.AddForce(direction * force);
    }

    public void EndSwordAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }
    public void SwordAttack() {
        LockMovement();
        if (moveInput.y > 0) // Up
        {
            swordAttack.AttackUp();
        }
        else if (moveInput.y < 0) // Down
        {
            swordAttack.AttackDown();
        }
        else if (spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.AttackRight();
        }
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }

}
