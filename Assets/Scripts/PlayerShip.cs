using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Shoot();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public override void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(xInput * speed, yInput * speed);

        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -5.3f, 5.3f);
        clampedPos.y = Mathf.Clamp(clampedPos.y, -2.84f, 2.84f);
        transform.position = clampedPos;
    }

    public override void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, gunPoint.position,transform.rotation);
        }
    }

    public void IncreaseHealth()
    {
        if (health < 3)
        {
            health++;
        }
    }

    public void IncreaseSpeed()
    {
        speed *= 2;
        StartCoroutine(SpeedCooldown());
    }
    IEnumerator SpeedCooldown()
    {
        yield return new WaitForSeconds(3f);
        speed /= 2;
    }
}
