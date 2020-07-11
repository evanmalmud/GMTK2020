using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDeath : MonoBehaviour
{

    Rigidbody2D rb;
    public SpriteRenderer sprite;
    Collider2D collider;
    AIPath aiPath;
    bool swapAfterBounce = false;
    public float hitForce = 1000;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aiPath = GetComponent<AIPath>();
        collider = GetComponent<CircleCollider2D>();
        collider.isTrigger = true;
    }

    private void FixedUpdate()
    {
        if (swapAfterBounce)
        {
            //Now is a bananapeel
            sprite.color = Color.yellow;
            aiPath.canMove = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.tag = "Slip";
            swapAfterBounce = false;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Mace" && gameObject.tag.Equals("Enemy"))
        {
            print("Mace hit enemy");
            col.gameObject.GetComponent<MaceMovement>().forceHit(col.transform);
            swapAfterBounce = true;
        }
        if (col.tag == "Player" && gameObject.tag.Equals("Enemy"))
        {
            print("Player hit enemy");
            col.gameObject.GetComponent<PlayerMovement>().forceHit(col.transform);
            col.gameObject.GetComponent<PlayerMovement>().takeDamage(1);
            swapAfterBounce = true;
        }
    }
}
