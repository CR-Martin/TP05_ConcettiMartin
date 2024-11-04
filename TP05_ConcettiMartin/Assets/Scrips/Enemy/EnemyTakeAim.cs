using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeAim : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision);
            TakeAim();

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other);
            TakeAim();

        }
    }

    private void TakeAim()
    {
        if (player == null) return;
        Vector2 direction = (player.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
