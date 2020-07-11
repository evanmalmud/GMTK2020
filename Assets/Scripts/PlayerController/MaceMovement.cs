using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float maxVelocity = 1f;
    public bool letVelocityLower = false;
    public Vector2 lastVelocity;
    public float hitForce = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (letVelocityLower) {
            Vector2 newVelocity = rb.velocity;
            if (newVelocity.magnitude < lastVelocity.magnitude) {
                Debug.Log("newVelocity" + newVelocity);
                Debug.Log("lastVelocity" + lastVelocity);
            }
            rb.velocity = newVelocity;

        }
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.tag == "Enemy" || col.collider.tag == "Bounce")
        {
            Debug.Log("Mace collider enter");
            //reverse velocity

            forceHit(col.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Enemy")
        {
            Debug.Log("Mace Trigger Enter collider");
            //reverse velocity

            forceHit(col.transform);
        }
        if (col.tag == "Bounce")
        {
            Debug.Log("Mace bounce Enter collider");
            //reverse velocity

            forceHit(col.transform);
        }

    }

    public void forceHit(Transform hittransform) {
        Vector2 dir = hittransform.position - transform.position;
        dir = -dir.normalized;
        rb.AddForce(dir * hitForce * rb.mass);
    }
}
