using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour , ITakeDamage
{
    [SerializeField] private int life;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int strength)
    {
        life -= strength;
        Debug.Log(life);
        if (life <= 0) {
            Destroy(gameObject);
        }
    }
}
