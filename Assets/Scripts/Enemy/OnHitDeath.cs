using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDeath : MonoBehaviour
{

    Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprite;
    Collider2D thiscollider;
    AIPath aiPath;
    public AudioSource slipSFX;
    bool swapAfterBounce = false;
    bool destroyAfterBounce = false;
    public float hitForce = 1000;
    AudioSource badnanaSFX;
    public bool isBoss = false;
    public int health = 3;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aiPath = GetComponent<AIPath>();
        thiscollider = GetComponent<CircleCollider2D>();
        thiscollider.isTrigger = true;
        badnanaSFX = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Mathf.Abs(aiPath.desiredVelocity.x) > Mathf.Abs(aiPath.desiredVelocity.y))
        {
            //moving horizontally more than vertically
            animator.SetBool("leftRight", true);
            animator.SetFloat("yVel", aiPath.desiredVelocity.y);
            if (aiPath.desiredVelocity.x > 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
        else
        {
            animator.SetBool("leftRight", false);
            animator.SetFloat("yVel", aiPath.desiredVelocity.y);
        }
    }

    private void FixedUpdate()
    {
        if (swapAfterBounce)
        {
            //Now is a bananapeel
            //sprite.color = Color.yellow;
            aiPath.canMove = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.tag = "Slip";
            swapAfterBounce = false;
        }
        if (destroyAfterBounce) {
            StartCoroutine(DeleteObject());
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Mace" && gameObject.tag.Equals("Enemy"))
        {   
            if(isBoss) {
                if(health > 1) {
                    //Still alive take damage and hit
                    health--;
                } else {
                    animator.SetBool("dead", true);
                    badnanaSFX.Play();
                    swapAfterBounce = true;
                }
                Vector2 dir = col.transform.position - transform.position;
                dir = -dir.normalized;
                col.gameObject.GetComponent<MaceMovement>().enemyForceHit(dir);

            } else {
                print("Mace hit enemy");
                Vector2 dir = col.transform.position - transform.position;
                dir = -dir.normalized;
                col.gameObject.GetComponent<MaceMovement>().enemyForceHit(dir);
                animator.SetBool("dead", true);
                badnanaSFX.Play();
                swapAfterBounce = true;
            }
        }
        if (col.tag == "Player" && gameObject.tag.Equals("Enemy"))
        {
            print("Player hit enemy");
            animator.SetBool("dead", true);
            badnanaSFX.Play();
            Vector2 dir = col.transform.position - transform.position;
            dir = -dir.normalized;
            col.gameObject.GetComponent<PlayerMovement>().forceHit(dir);
            col.gameObject.GetComponent<PlayerMovement>().takeDamage(1);
            swapAfterBounce = true;
        }

        if (col.tag == "Player" && gameObject.tag.Equals("Slip"))
        {
            destroyAfterBounce = true;
            slipSFX.Play();
            thiscollider.enabled = false;
        }
    }

    private IEnumerator DeleteObject() {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
