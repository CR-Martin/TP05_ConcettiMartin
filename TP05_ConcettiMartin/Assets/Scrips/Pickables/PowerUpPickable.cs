using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IpowerUp hit = other.gameObject.GetComponent<IpowerUp>();
            AudioManager.Instance.PlayEffect("Power up");
            hit.ActivatePowerUp();
            Destroy(gameObject);
        }
    }
}
