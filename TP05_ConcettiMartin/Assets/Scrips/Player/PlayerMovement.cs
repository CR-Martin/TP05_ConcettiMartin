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
    private bool _facingRight = true;
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

        if (move > 0)
        {
            Flip();
        }
        else if (move < 0)
        {
            Flip();
        }

        playerBody.velocity = new Vector2(move * speed * Time.deltaTime, playerBody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded == false)
        {
            playerBody.AddForce(new Vector2(playerBody.velocity.x, jump));
        }
    }

    private void Flip()
    {
        if ((move < 0 && _facingRight) || (move > 0 && !_facingRight))
        {
            _facingRight = !_facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
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
