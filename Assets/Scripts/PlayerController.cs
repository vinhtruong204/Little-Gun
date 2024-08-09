using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    private float playerSpeed = 0.1f;
    // Update is called once per frame
    void Update()
    {
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);

        //     Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        //     transform.position = touchPos;
        // }

        float horizontalMove = joystick.Horizontal * playerSpeed;

        transform.position = new Vector3(transform.position.x + horizontalMove, transform.position.y);
        // transform.position.x += horizontalMove;
    }
}
