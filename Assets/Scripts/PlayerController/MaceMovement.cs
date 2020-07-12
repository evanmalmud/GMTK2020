using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float maxVelocity = 1f;
    public bool letVelocityLower = false;
    public Vector2 lastVelocity;
    public float wallhitForce = 1000;
    public float enemyhitForce = 1000;
    public float magnetForce = 100;

    AudioSource maceSFX;
    public ScreenShake mainCamera;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maceSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*8if(Input.GetButton("Submit")) {
            print("A presed");
            forceHit(Vector2.right, wallhitForce);
        }
        if (Input.GetButton("Cancel"))
        {
            print("B presed");
            forceHit(Vector2.left, wallhitForce);
        }    public void loadScene()
    {
        SceneManager.LoadScene("Game");
    }**/
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

        if (col.collider.tag == "Bounce")
        {
            Debug.Log("Mace Wall Bounce");
            // and lose control
            Vector2 ndir = Vector2.zero;
            if (col.collider.name.Equals("Top"))
            {
                ndir = Vector2.down;
            }
            else if (col.collider.name.Equals("Bottom"))
            {
                ndir = Vector2.up;
            }
            else if (col.collider.name.Equals("Right"))
            {
                ndir = Vector2.left;
            }
            else if (col.collider.name.Equals("Left"))
            {
                ndir = Vector2.right;
            }
            maceSFX.Play();
            forceHit(ndir, wallhitForce);
        }
        if(col.collider.tag == "SuperBounce") {
            Debug.Log("Mace super Bounce");
            maceSFX.Play();
            forceHit(col.transform, wallhitForce * 3);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Bounce")
        {
            Debug.Log("Mace Bounce");
            // and lose control
            Vector2 ndir = Vector2.zero;
            if (col.name.Equals("Top"))
            {
                ndir = Vector2.down;
            }
            else if (col.name.Equals("Bottom"))
            {
                ndir = Vector2.up;
            }
            else if (col.name.Equals("Right"))
            {
                ndir = Vector2.left;
            }
            else if (col.name.Equals("Left"))
            {
                ndir = Vector2.right;
            }
            maceSFX.Play();
            forceHit(ndir, wallhitForce);
        }
    }

    public void forceHit(Transform hittransform, float force) {
        mainCamera.ShakeScreenDefault();
        animator.SetTrigger("hit");
        Vector2 dir = hittransform.position - transform.position;
       // print("forhit" + dir);
        dir = -dir.normalized;
        rb.AddForce(dir * force * rb.mass);
    }

    public void forceHit(Vector2 hittransform, float force)
    {
        mainCamera.ShakeScreenDefault();
        animator.SetTrigger("hit");
        rb.AddForce(hittransform.normalized * force * rb.mass);
    }

    public void enemyForceHit(Vector2 hittransform) {
        forceHit(hittransform, enemyhitForce);
    }

    public void magnetPush(Transform hittransform, float force)
    {
        Vector2 dir = transform.position - hittransform.position;
        rb.AddForce(dir * force * rb.mass);
    }

    public void magnetPull(Transform hittransform, float force)
    {
        Vector2 dir = transform.position - hittransform.position;
        dir = -dir.normalized;
        rb.AddForce(dir * force * rb.mass);
    }
}
