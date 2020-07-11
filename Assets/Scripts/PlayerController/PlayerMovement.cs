using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;

    public float movementSpeed = 1f;   //Movement Speed of the Player
    public Vector2 movement;           //Movement Axis

    public int health = 3;
    public float hitForce = 1000;

    public float runSpeed = 20.0f;

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
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.tag == "Enemy")
        {
            Debug.Log("Player Hit");
            // force is how forcefully we will push the player away from the enemy.
            // Calculate Angle Between the collision point and the player
            Vector2 dir = col.transform.position - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            rb.AddForce(dir * hitForce * rb.mass);
            health--;
        }
    }
}
