using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        FlipDirection();
        UpdateAnimationParameters();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }

    void FlipDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if ((horizontalInput > 0 && !facingRight) || (horizontalInput < 0 && facingRight))
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void UpdateAnimationParameters()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        bool isRunning = (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f);

        animator.SetBool("isRunning", isRunning);
    }

    // Method to check if the player is facing right
    public bool IsFacingRight()
    {
        return facingRight;
    }
}
