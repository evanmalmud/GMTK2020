using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDeath : MonoBehaviour
{

    Rigidbody2D rb;

    bool destroyAfterBounce = false;
    public float hitForce = 1000;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (destroyAfterBounce)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {   

        if (col.collider.tag == "Mace")
        {
            destroyAfterBounce = true;
        }

        if (col.collider.tag == "Player" || col.collider.tag == "Mace")
        {
            // force is how forcefully we will push the player away from the enemy.
            // Calculate Angle Between the collision point and the player
            Vector2 dir = col.transform.position - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            rb.AddForce(dir * hitForce * rb.mass);
        }
    }
}
