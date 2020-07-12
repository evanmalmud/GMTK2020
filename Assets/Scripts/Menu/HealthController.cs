using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Image[] images;

    public int totalhealth;

    // Start is called before the first frame update
    void Start()
    {
        totalhealth = images.Length;
    }

    public void healthUpdate(int currentHealth) {
        int count = 1;
        foreach(Image image in images) {
            if(count <= currentHealth) {
                //Heart ON
                image.enabled = true;
            } else {
                //heart off
                image.enabled = false;
            }
            count++;
        }
        
    }
}
