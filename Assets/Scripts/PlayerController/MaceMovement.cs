using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float maxVelocity = 1f;
    public bool letVelocityLower = false;
    public Vector2 lastVelocity;

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
            Debug.Log("Mace collider");
            //reverse velocity
            Vector2 newVelocity = new Vector2();
            newVelocity.x = rb.velocity.x * -1;
            newVelocity.y = rb.velocity.y * -1;
            rb.velocity = newVelocity;
            float newAnuglarVelocity = rb.angularVelocity * -1;
            rb.angularVelocity = newAnuglarVelocity;
        }
    }
}
