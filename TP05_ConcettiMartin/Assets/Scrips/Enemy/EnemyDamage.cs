using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int strength = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ITakeDamage hit = collision.gameObject.GetComponent<ITakeDamage>();
        hit.TakeDamage(strength);
        Destroy(gameObject);
    }
}
