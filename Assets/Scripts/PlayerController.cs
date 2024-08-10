using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    private float playerSpeed = 0.1f;
    private float jumpSpeed = 5.0f;
    private Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);

        //     Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        //     transform.position = touchPos;
        // }


        PlayerMove();

    }

    public void PlayerMove()
    {
        // If moved horizontally, it approaches 0
        if (joystick.Horizontal <= 0.2f && joystick.Horizontal >= -0.2f) return; // Not move

        // Move the player horizontal
        float horizontalMove = joystick.Horizontal * playerSpeed;
        playerRb.AddForce(new Vector2(horizontalMove, 0.0f), ForceMode2D.Impulse);
    }

    public void PlayerJump()
    {
        // User request jump
        playerRb.AddForce(new Vector2(0.0f, jumpSpeed), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
