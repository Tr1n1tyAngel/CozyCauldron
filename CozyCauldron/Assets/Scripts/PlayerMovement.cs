using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;           // Speed of the character
    public float jumpForce = 7.0f;       // Force of the jump
    private Rigidbody2D rb;              // Reference to the Rigidbody2D component
    private bool isGrounded = true;      // Boolean to check if the player is grounded
    private bool facingRight = true;     // Track which way the player is facing
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Only process movement input if the character is grounded
        if (isGrounded)
        {
            // Movement input from the player
            float moveHorizontal = Input.GetAxis("Horizontal");

            animator.SetFloat("Speed",Mathf.Abs(moveHorizontal));
            // Moving the Rigidbody2D based on input and speed
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

            // Check if sprite needs to be flipped
            if (moveHorizontal > 0 && !facingRight)
                Flip();
            else if (moveHorizontal < 0 && facingRight)
                Flip();
        }

        // Checking if the jump button (space bar) is pressed and the character is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // Set isGrounded to false to prevent double jumping
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Ensure the GameObject has a tag named "Ground"
        {
            isGrounded = true; // Set isGrounded to true when touching the ground
        }
    }

    // Method to flip the player sprite
    void Flip()
    {
        facingRight = !facingRight; // Switch the way the player is labelled as facing
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Flip the player's sprite by multiplying the x local scale by -1
        transform.localScale = theScale;
    }
}
