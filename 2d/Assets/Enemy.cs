using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; // Speed of the character
    public float leftLimit = -2f; // Left boundary of movement area
    public float rightLimit = 2f; // Right boundary of movement area
    private Rigidbody2D rb;
    private float movement = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the character
    }

    void Update()
    {
        // Get the horizontal movement input (left and right arrow keys)
        movement = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Move the character horizontally within the defined area
        float xPos = transform.position.x + movement * speed * Time.deltaTime;
        xPos = Mathf.Clamp(xPos, leftLimit, rightLimit); // Clamp the position within the movement area
        rb.MovePosition(new Vector2(xPos, transform.position.y)); // Move the character to the new position
    }
}
