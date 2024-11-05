using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAim : MonoBehaviour
{
    [SerializeField] private BulletSO data;

    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rb;
    private float timer;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * data.Velocity;

        float rot = Mathf.Atan2(-direction.y,-direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > data.LifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ITakeDamage hit = collision.gameObject.GetComponent<ITakeDamage>();
            hit.TakeDamage(data.Strength);
        }
           
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    ITakeDamage hit = collision.gameObject.GetComponent<ITakeDamage>();
    //    hit.TakeDamage(data.Strength);
    //    Destroy(gameObject);
    //}

}
