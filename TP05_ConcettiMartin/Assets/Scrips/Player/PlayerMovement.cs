using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;

    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool grounded;

    [SerializeField] private float speed = 1000;
    public float jump = 200;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        
        if (Mathf.Abs(xInput) > 0) { 
            playerBody.velocity = new Vector2(xInput * speed *Time.deltaTime, playerBody.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            playerBody.AddForce(new Vector2(playerBody.velocity.x, jump));
        }
        
    }

    private void FixedUpdate()
    {
        

    }

    void CheckGrounded()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max,groundMask).Length > 0;
    }
}
