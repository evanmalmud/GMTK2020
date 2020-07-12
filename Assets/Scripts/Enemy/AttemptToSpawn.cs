using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptToSpawn : MonoBehaviour
{

    private bool playerhere = false;


    public bool attemptToSpawnEnemy(GameObject enemy, GameObject player) {
        if(!playerhere) {
            GameObject enemyGO = Instantiate(enemy, this.transform.position, this.transform.rotation);
            enemyGO.GetComponent<AIDestinationSetter>().target = player.transform;
            return true;
        }
        return false;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            playerhere = true;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            playerhere = false;
        }

    }
}
