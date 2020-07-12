using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInGameOVer : MonoBehaviour
{
    [SerializeField] private Image fadeImage = null;
    [SerializeField] private TextMeshProUGUI specialText = null;
    // Start is called before the first frame update
    void Start()
    {
        Color newalpha = fadeImage.color;
        newalpha.a = 0;
        fadeImage.color = newalpha;
        specialText.enabled = false;
    }

    private void Update()
    {
        if (Input.GetButton("Submit") && fadeImage.color.a == 1)
        {
            SceneManager.LoadScene("Game");
        }

    }

    // Update is called once per frame
    public void gameOver()
    {
        this.GetComponent<FadeInOut>().fadeIn();
    }

    public void specialGameOver()
    {
        this.GetComponent<FadeInOut>().fadeIn();
        specialText.enabled = true;

    }
}

