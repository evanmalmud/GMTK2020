using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesControlelr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Mace")
        {
            print("Mace hit spikes");
            Vector2 dir = col.transform.position - transform.position;
            dir = -dir.normalized;
            col.gameObject.GetComponent<MaceMovement>().enemyForceHit(dir);
        }
        if (col.tag == "Player" && gameObject.tag.Equals("Enemy"))
        {
            print("Player hit spikes");
            Vector2 dir = col.transform.position - transform.position;
            //dir = -dir.normalized;
            col.gameObject.GetComponent<PlayerMovement>().forceHit(dir);
            col.gameObject.GetComponent<PlayerMovement>().takeDamage(1);
        }

    }
}
