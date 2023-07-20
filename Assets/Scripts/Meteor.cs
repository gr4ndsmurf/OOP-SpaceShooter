using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (transform.position.y > 7 || transform.position.y < -3.94 || transform.position.x > 6.6 || transform.position.x < -6.6)
        {
            Destroy(gameObject);
        }
    }
}
