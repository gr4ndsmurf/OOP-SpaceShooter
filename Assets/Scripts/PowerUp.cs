using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerShip"))
        {
            ApplyPowerUp(collision.GetComponent<PlayerShip>());
            Destroy(gameObject);
        }
    }

    private void ApplyPowerUp(PlayerShip playerShip)
    {
        switch (type)
        {
            case PowerUpType.Health:
                playerShip.IncreaseHealth();
                break;
            case PowerUpType.Speed:
                playerShip.IncreaseSpeed();
                break;
        }
    }
}
