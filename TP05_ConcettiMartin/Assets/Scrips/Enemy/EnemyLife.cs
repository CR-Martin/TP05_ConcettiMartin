using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class EnemyLife : MonoBehaviour, ITakeDamage
{
    [SerializeField] private EnemySO data;
    [SerializeField] private Slider lifeBar;
    [SerializeField] private GameObject deadParticles;

    private int life;
    void Start()
    {
        life = data.Maxlife;
        UpdateHealthBar(life, data.Maxlife);

    }
    private void UpdateHealthBar(int currentLife, int maxLife)
    {
        float temp1 = currentLife;
        float temp2 = maxLife;
        lifeBar.value = temp1 / temp2;

    }

    public void TakeDamage(int strength)
    {
        AudioManager.Instance.PlayEffect("Hurt");

        life -= strength;
        Debug.Log(life);
        if (life <= 0)
        {
            Instantiate(deadParticles, transform.position, Quaternion.identity);
            AudioManager.Instance.PlayEffect("Explosion");
            Destroy(gameObject);
        }
        UpdateHealthBar(life, data.Maxlife);

    }
}
