using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickable : MonoBehaviour
{
    [SerializeField] private LifePickableSO data;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player is healing");
            ITakeDamage hit = other.gameObject.GetComponent<ITakeDamage>();
            hit.TakeDamage(data.AmountOfLife);
            Destroy(gameObject);
        }
    }
}
