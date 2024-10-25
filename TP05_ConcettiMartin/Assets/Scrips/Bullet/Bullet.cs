using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private Rigidbody2D rb;
    private int strength = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        ITakeDamage hit = collision.gameObject.GetComponent<ITakeDamage>();
        if (hit != null)
        {
            hit.TakeDamage(strength);
        }

        Destroy(gameObject);
    }


}
