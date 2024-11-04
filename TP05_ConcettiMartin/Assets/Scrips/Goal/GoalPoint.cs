using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoalPoint : MonoBehaviour
{
    public static event Action WinGame;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            WinGame?.Invoke();
        }
    }
}
