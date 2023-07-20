using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float backgroundHeight;
    private SpriteRenderer spriteRenderer;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        backgroundHeight = spriteRenderer.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x , transform.position.y - speed * Time.deltaTime);
        if (transform.position.y <= -backgroundHeight)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 2 * backgroundHeight);
        }
    }
}
