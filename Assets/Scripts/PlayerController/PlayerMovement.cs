using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public SpriteRenderer playerSprite;
    public Animator animator;

    public float movementSpeed = 1f;   //Movement Speed of the Player
    public Vector2 movement;           //Movement Axis
    public ParticleSystem dust;
    public int health = 3;
    public float hitForce = 1000;
    public float slipForce = 10;
    public float lostControlTime = 2f;
    public float lostControlCounter = 0f;

    AudioSource playeroffWall;

    public HealthController hp;

    public ScreenShake mainCamera;

    public FadeInGameOVer gameOver;

    public Vector2 lastMovement;
    public Vector2 lastVelocity;

    public AudioSource hurtAudio;

    bool playerinvilnerable = false;

    public int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playeroffWall = GetComponent<AudioSource>();
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
            rb.AddForce(movement * movementSpeed,ForceMode2D.Impulse);
            lastVelocity = rb.velocity;
        } else {
            dust.Play();
            rb.velocity = lastVelocity;
            //rb.AddForce(lastMovement * movementSpeed, ForceMode2D.Impulse);
        }

        lostControlCounter -= Time.deltaTime;
        if(Mathf.Abs(movement.x) > Mathf.Abs(movement.y)) {
            //moving horizontally more than vertically
            animator.SetBool("leftRight", true);
            animator.SetFloat("yVel", movement.y);
            if (movement.x > 0)
            {
                playerSprite.flipX = true;
            }
            else
            {
                playerSprite.flipX = false;
            }
        } else {
            animator.SetBool("leftRight", false);
            animator.SetFloat("yVel", movement.y);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Bounce")
        {

            Debug.Log("Player Wall Bounce");
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
            forceHit(ndir);
            playeroffWall.Play();
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Slip")
        {
            Debug.Log("Player Slip");
            // and lose control
            mainCamera.ShakeScreenDefault();
            lostControlCounter = lostControlTime;
        }
        if (col.tag == "Bounce")
        {
            
            Debug.Log("Player Wall Bounce");
            // and lose control
            Vector2 ndir = Vector2.zero;
            if(col.name.Equals("Top")) {
                ndir = Vector2.down;
            }
            else if (col.name.Equals("Bottom")) {
                ndir = Vector2.up;
            }
            else if (col.name.Equals("Right")) {
                ndir = Vector2.left;
            }
            else if (col.name.Equals("Left")) {
                ndir = Vector2.right;
            }
            forceHit(ndir);
            playeroffWall.Play();
        }
    }


    public void forceHit(Transform hittransform)
    {
        mainCamera.ShakeScreenDefault();
        Vector2 dir = hittransform.position - transform.position;
        dir = -dir.normalized;
        rb.AddForce(dir * hitForce * rb.mass);
    }

    public void forceHit(Vector2 hittransform)
    {
        mainCamera.ShakeScreenDefault();
        rb.AddForce(hittransform.normalized * hitForce * rb.mass);
    }
    public void takeDamage(int amount)
    {
        if (!playerinvilnerable) {
            health -= amount;
            hp.healthUpdate(health);
            StartCoroutine(playerHurt());
            hurtAudio.Play();
            if (health == 0)
            {
                //Game Over
                gameOver.gameOver(score);
            }
         }
    }

    public void addScore(int val) {
        score += val;
    }

    IEnumerator playerHurt()
    {
        playerinvilnerable = true;
        Color playerColor = playerSprite.color;
        Color alphaColor = playerColor;
        alphaColor.a = 0;

        //print("fade in routine");
        playerSprite.color = alphaColor;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = playerColor;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = alphaColor;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = playerColor;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = alphaColor;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = playerColor;

        playerinvilnerable = false;
    }
}
