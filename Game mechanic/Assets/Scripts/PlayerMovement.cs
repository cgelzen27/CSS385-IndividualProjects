using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public bool isFacingRight = false;

    Rigidbody2D rb;
    Animator animator;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Orient the character correctly when walking
        if(horizontalInput > 0f && isFacingRight || horizontalInput < 0f && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    // Hook the animation
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
        animator.SetFloat("moveX", rb.velocityX);
        animator.SetFloat("moveY", rb.velocityY);
    }
}