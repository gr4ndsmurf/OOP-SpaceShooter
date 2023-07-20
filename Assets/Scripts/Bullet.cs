using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int bulletSpeed;

    private GameManager gameManager;

    private Rigidbody2D bulletRB;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        bulletRB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        bulletRB.velocity = transform.up * bulletSpeed;
        StartCoroutine(BulletRange());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("PlayerShip"))
        {
            collision.collider.GetComponent<PlayerShip>().TakeDamage(damage);
            if (collision.collider.GetComponent<PlayerShip>().isDestroyed)
            {
                gameManager.GameOver();
            }
            Destroy(gameObject);
        }
        if (collision.transform.CompareTag("EnemyShip"))
        {
            collision.collider.GetComponent<EnemyShip>().TakeDamage(damage);
            if (collision.collider.GetComponent<EnemyShip>().isDestroyed)
            {
                gameManager.AddScore(10);
            }
            Destroy(gameObject);
        }
    }

    IEnumerator BulletRange()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
