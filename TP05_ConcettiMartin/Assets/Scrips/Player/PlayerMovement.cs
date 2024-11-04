using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IpowerUp
{
    private Rigidbody2D playerBody;

    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private bool grounded;

    [SerializeField] private PlayerSO data;

    private float speed;
    private float jump;
    private bool jumpPowerUp = false;
    private bool canDoubleJump = true;

    private bool facingRight = true;

    private float move;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        speed=data.MovementSpeed;
        jump=data.JumpForce;
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
            AudioManager.Instance.PlayEffect("Jump");
            playerBody.AddForce(new Vector2(playerBody.velocity.x, jump));
        }
        if (Input.GetButtonDown("Jump") && grounded == true && jumpPowerUp == true && canDoubleJump == true)
        {
            AudioManager.Instance.PlayEffect("Jump");
            playerBody.AddForce(new Vector2(playerBody.velocity.x, jump));
            canDoubleJump = false;
        }
    }

    private void Flip()
    {
        if ((move < 0 && facingRight) || (move > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            canDoubleJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    public void ActivatePowerUp()
    {
        jumpPowerUp = true;
    }

}
