using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    protected int health;
    protected int speed;
    protected bool isDestroyed;

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
    }
}
