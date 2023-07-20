using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int bulletSpeed;

    private GameManager gameManager;

    private Rigidbody2D bulletRB;

    private SpriteRenderer spriteRenderer;
    public Sprite img;

    private BoxCollider2D collider;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        bulletRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        bulletRB.velocity = transform.up * bulletSpeed;
        StartCoroutine(BulletRange());

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerShip"))
        {
            collision.GetComponent<PlayerShip>().TakeDamage(damage);
            if (collision.GetComponent<PlayerShip>().isDestroyed)
            {
                gameManager.GameOver();
            }
            DestroyBullet();
        }
        if (collision.transform.CompareTag("EnemyShip"))
        {
            collision.GetComponent<EnemyShip>().TakeDamage(damage);
            if (collision.GetComponent<EnemyShip>().isDestroyed)
            {
                gameManager.AddScore(10);
            }
            DestroyBullet();
        }
        if (collision.CompareTag("Bullet"))
        {
            DestroyBullet();
        }
        if (collision.CompareTag("Meteor"))
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        collider.enabled = false;
        spriteRenderer.sprite = img;
        StartCoroutine(BulletDestroy());
    }

    IEnumerator BulletRange()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
