using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    public int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected Transform gunPoint;

    protected Rigidbody2D rb;

    public bool isDestroyed;

    public abstract void Move();
    public abstract void Shoot();

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyShip();
        }
    }

    protected virtual void DestroyShip()
    {
        isDestroyed = true;
        // Gemiyi yok etme iþlemleri
        Destroy(gameObject);
    }
}
