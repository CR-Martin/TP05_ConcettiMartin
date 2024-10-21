using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;

    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private bool grounded;

    [SerializeField] private float speed = 1000;
    public float jump = 200;

    public float move;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        move = Input.GetAxis("Horizontal");

       

        playerBody.velocity = new Vector2(move * speed * Time.deltaTime, playerBody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded == false)
        {
            playerBody.AddForce(new Vector2(playerBody.velocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

}
