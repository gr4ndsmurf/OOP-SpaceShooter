using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    public GameObject playerShip;
    private bool shootingDelayed;

    [SerializeField]
    private float damping;

    private void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("PlayerShip");
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        RotateToPlayer();
        Move();
        Shoot();
    }

    public override void Move()
    {
        rb.velocity = Vector2.down * speed;

        if (transform.position.y < -3.94)
        {
            Destroy(gameObject);
        }
    }

    public void RotateToPlayer()
    {
        Vector2 direction = new Vector2(playerShip.transform.position.x - transform.position.x, playerShip.transform.position.y - transform.position.y);
        transform.up = Vector3.Lerp(transform.up, direction, damping);
    }

    public override void Shoot()
    {
        if (shootingDelayed == false)
        {
            shootingDelayed = true;
            Instantiate(bullet, gunPoint.position, gameObject.transform.rotation);
            StartCoroutine(shootingCooldown());
        }
    }

    IEnumerator shootingCooldown()
    {
        yield return new WaitForSeconds(1f);
        shootingDelayed = false;
    }
}

