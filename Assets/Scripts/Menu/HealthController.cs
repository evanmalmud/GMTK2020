using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Animator[] images;

    public int totalhealth;

    // Start is called before the first frame update
    void Start()
    {
        totalhealth = images.Length;
    }

    public void healthUpdate(int currentHealth) {
        int count = 1;
        foreach(Animator image in images) {
            if(count <= currentHealth) {
                //Heart ON
                image.SetBool("isOn", true);
                //image.enabled = true;
            } else {
                //heart off
                image.SetBool("isOn", false);
                //image.enabled = false;
            }
            count++;
        }
        
    }
}
