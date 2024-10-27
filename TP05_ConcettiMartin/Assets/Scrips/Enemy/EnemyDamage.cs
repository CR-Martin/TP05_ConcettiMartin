using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private EnemySO data;

    int strength;
    void Start()
    {
        strength=data.Strength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ITakeDamage hit = collision.gameObject.GetComponent<ITakeDamage>();
        hit.TakeDamage(strength);
        //Destroy(gameObject);
    }
}
