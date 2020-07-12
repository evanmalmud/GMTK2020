using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInGameOVer : MonoBehaviour
{
    [SerializeField] private Image fadeImage = null;
    [SerializeField] private Image score = null;
    [SerializeField] private TextMeshProUGUI scoretext = null;
    [SerializeField] private TextMeshProUGUI buttonText= null;
    [SerializeField] private Image button = null;
    //[SerializeField] private TextMeshProUGUI specialText = null;
    // Start is called before the first frame update

    private FadeInOut fadeInOut;
    void Start()
    {
        fadeInOut = this.GetComponent<FadeInOut>();
        Color newalpha = fadeImage.color;
        newalpha.a = 0;
        fadeImage.color = newalpha;
        //specialText.enabled = false;

        newalpha = score.color;
        newalpha.a = 0;
        score.color = newalpha;

        newalpha = button.color;
        newalpha.a = 0;
        button.color = newalpha;

        newalpha = scoretext.color;
        newalpha.a = 0;
        scoretext.color = newalpha;

        newalpha = buttonText.color;
        newalpha.a = 0;
        buttonText.color = newalpha;

    }

    private void Update()
    {
        if (Input.GetButton("Submit") && fadeImage.color.a == 1)
        {
            SceneManager.LoadScene("Game");
        }

    }

    // Update is called once per frame
    public void gameOver(int scorenum)
    {
        scoretext.text = scorenum.ToString();
        fadeInOut.setImage(fadeImage);
        fadeInOut.fadeIn();
        fadeInOut.setImage(score);
        fadeInOut.fadeIn();
        fadeInOut.setImage(button);
        fadeInOut.fadeIn();

        fadeInOut.setText(scoretext);
        fadeInOut.fadeInText();
        fadeInOut.setText(buttonText);
        fadeInOut.fadeInText();
    }

    public void specialGameOver()
    {
        this.GetComponent<FadeInOut>().fadeIn();
        //specialText.enabled = true;

    }
}

