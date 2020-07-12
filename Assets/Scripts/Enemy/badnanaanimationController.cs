using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badnanaanimationController : MonoBehaviour
{
    Animator animator;
    public Rigidbody2D rb;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
        {
            //moving horizontally more than vertically
            animator.SetBool("leftRight", true);
            animator.SetFloat("yVel", rb.velocity.y);
            if (rb.velocity.x > 0)
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
            animator.SetFloat("yVel", rb.velocity.y);
        }
    }
}
