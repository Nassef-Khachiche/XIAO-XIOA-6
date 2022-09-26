using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private Scrollbar staminaBar;
    //[SerializeField] private float stamina = 15f;
    [SerializeField] private float runSpeed = 5f;
    Vector2 moveInput;
    Rigidbody2D rb;
    bool enemyHit = false;
    Vector2 playerPosition;

    // Jump
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float jumpingPower = 12f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        playerPosition = rb.position;
    }

    void Update()
    {
        Move();
        FlipSprite();

        if (enemyHit == true)
        {
            rb.position = playerPosition;
        }
    }

    public bool IsGrounded() 
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }


    void Move()
    {

        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb.velocity.y);

        if (moveInput.y > 0 && IsGrounded())
        {
            playerVelocity = new Vector2(moveInput.x, jumpingPower);
        }

        rb.velocity = playerVelocity;

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FlipSprite()
    {
        bool playerHasSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), transform.localScale.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHit = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHit = false;
        }
    }
}
