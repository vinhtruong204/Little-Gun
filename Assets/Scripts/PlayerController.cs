using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables relate joystick
    public Joystick joystick;
    private float boundTriggerMove = 0.2f;

    // Player move
    private float playerSpeed = 3.0f;
    private float jumpPower = 5.0f;
    private bool isOnground;
    private int jumpCount;

    // Player component
    private Rigidbody2D playerRb;
    private BoxCollider2D boxCollider2D;
    private Vector3 defaultPos = new Vector3(-2.62f, -0.4f, 0);

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Move the character
        PlayerMoveHorizontal();

        // Adjust box collider when player is falling
        HandleFall();

    }

    private void HandleFall()
    {
        // Check player is jumping or falling
        boxCollider2D.enabled = playerRb.velocity.y <= 0 ? true : false;
    }

    private void PlayerMoveHorizontal()
    {
        // If moved horizontally, it approaches 0
        if (joystick.Horizontal <= boundTriggerMove && joystick.Horizontal >= -boundTriggerMove) return; // Not move

        // Set velocity for rigidbody
        Vector2 newVelocityRb = new Vector2(joystick.Horizontal * playerSpeed, playerRb.velocity.y);
        playerRb.velocity = newVelocityRb;
    }


    public void PlayerJump()
    {
        // Check double jump
        if (jumpCount >= 2)
        {
            return;
        }

        // Set up for double jump
        if (jumpCount < 2 || isOnground)
        {
            // User request jump
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpPower);

            // Reset onGround boolean
            isOnground = false;

            // Increase jump count
            jumpCount++;
        }
    }

    public void ResetPos()
    {
        // Reset position to default when player fall into the abyss
        transform.position = defaultPos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            isOnground = true;
            if (other.gameObject.transform.position.y < transform.position.y)
            {
                boxCollider2D.enabled = false;

            }
        }
    }
}
