using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;

    public float movementSpeed = 1f;   //Movement Speed of the Player
    public Vector2 movement;           //Movement Axis
    public ParticleSystem dust;
    public int health = 3;
    public float hitForce = 1000;
    public float slipForce = 10;
    public float lostControlTime = 2f;
    private float lostControlCounter = 0f;
    public float runSpeed = 20.0f;

    private Vector2 lastMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if(lostControlCounter <= 0f)
        {
            lastMovement = movement;
            rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        } else {
            dust.Play();
            rb.MovePosition(rb.position + lastMovement * movementSpeed * Time.fixedDeltaTime);
        }

        lostControlCounter -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Slip")
        {
            Debug.Log("Player Slip");
            // and lose control
            lostControlCounter = lostControlTime;
        }
    }


    public void forceHit(Transform hittransform)
    {
        Vector2 dir = hittransform.position - transform.position;
        dir = -dir.normalized;
        rb.AddForce(dir * hitForce * rb.mass);
    }
    public void takeDamage(int amount) {
        health -= amount;
    }
}
