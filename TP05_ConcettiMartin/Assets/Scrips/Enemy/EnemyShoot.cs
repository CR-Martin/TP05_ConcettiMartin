using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private BulletSO data;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private GameObject player;

    private float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        Debug.Log(distance);
        if (distance < data.Range)
        {
            timer += Time.deltaTime;

            if (timer > data.FireRate)
            {
                timer = 0;
                Shoot();
            }
        }

      
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPos.position,Quaternion.identity);

    }
}
