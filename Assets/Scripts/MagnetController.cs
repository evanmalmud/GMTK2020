using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{

    private bool macehere = false;
    GameObject mace = null;
    public float magenetforce = 1000;
    public bool isPush = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(macehere) {
            if(isPush) {
                mace.GetComponent<MaceMovement>().magnetPush(this.transform, magenetforce);
            } else {
                mace.GetComponent<MaceMovement>().magnetPull(this.transform, magenetforce);
            }
        }   
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Mace")
        {
            Debug.Log("Mace in Zone");
            mace = col.gameObject;
            macehere = true;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {

        if (col.tag == "Mace")
        {
            macehere = false;
        }

    }


}
