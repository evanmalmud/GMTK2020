using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutOnStart : MonoBehaviour
{
    [SerializeField] private Image fadeImage = null;
    // Start is called before the first frame update
    void Start()
    {
        Color newalpha = fadeImage.color;
        newalpha.a = 1;
        fadeImage.color = newalpha;
        this.GetComponent<FadeInOut>().fadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
