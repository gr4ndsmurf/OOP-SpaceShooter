using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    void Update()
    {
        // Mermi Hareketi
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerShip"))
        {
            collision.GetComponent<PlayerShip>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.transform.CompareTag("EnemyShip"))
        {
            collision.GetComponent<EnemyShip>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
