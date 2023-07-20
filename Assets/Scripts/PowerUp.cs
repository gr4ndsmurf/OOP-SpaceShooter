using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType type;

    public float speed;
    private void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        if (transform.position.y < -3.94)
        {
            Destroy(gameObject);
        }
    }

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
