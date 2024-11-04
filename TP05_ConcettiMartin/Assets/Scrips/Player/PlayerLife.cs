using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerLife : MonoBehaviour , ITakeDamage
{
    public static event Action OnGameOver;

    [SerializeField] private PlayerSO data;
    [SerializeField] private GameObject inmunityIndicator;
    [SerializeField] private Slider lifeBar;

    private int life;
    private bool inmune;
    void Start()
    {
        life=data.Maxlife;
        UpdateHealthBar(life, data.Maxlife);
        inmune = false;
    }

    public void TakeDamage(int strength)
    {
        if (inmune)
        {
        }
        else {

            life -= strength;

            if (life <= 0)
            {
                OnGameOver?.Invoke();
            }

            UpdateHealthBar(life, data.Maxlife);

            StartCoroutine(InmunityTimer());
        }
    }

    private void UpdateHealthBar(int currentLife, int maxLife)
    {
        float temp1 = currentLife;
        float temp2 = maxLife;
        lifeBar.value = temp1 / temp2;

    }
    IEnumerator InmunityTimer()
    {
        inmunityIndicator.SetActive(true);
        inmune = true;
        yield return new WaitForSeconds(data.InmunityTime);
        inmunityIndicator.SetActive(false);
        inmune = false;

    }
}
