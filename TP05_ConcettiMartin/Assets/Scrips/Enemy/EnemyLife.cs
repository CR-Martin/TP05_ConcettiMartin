using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour, ITakeDamage
{
    [SerializeField] private EnemySO data;

    private int life;
    void Start()
    {
        life = data.Maxlife;
    }

    public void TakeDamage(int strength)
    {
        life -= strength;
        Debug.Log(life);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
