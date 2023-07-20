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

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        bulletRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            spriteRenderer.sprite = img;
            StartCoroutine(BulletDestroy());
        }
        if (collision.transform.CompareTag("EnemyShip"))
        {
            collision.collider.GetComponent<EnemyShip>().TakeDamage(damage);
            if (collision.collider.GetComponent<EnemyShip>().isDestroyed)
            {
                gameManager.AddScore(10);
            }
            spriteRenderer.sprite = img;
            StartCoroutine(BulletDestroy());
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            spriteRenderer.sprite = img;
            StartCoroutine(BulletDestroy());
        }
        if (collision.collider.CompareTag("Meteor"))
        {
            spriteRenderer.sprite = img;
            StartCoroutine(BulletDestroy());
        }
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
