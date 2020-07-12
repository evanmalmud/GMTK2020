using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Black Image covering the UI.")]
    [SerializeField] private Image fadeImage = null;
    [SerializeField] private TextMeshProUGUI fadeText = null;
    [Space(10)]
    [Range(0, 20)]
    [Tooltip("Duration of Fade In.")]
    [SerializeField] private float fadeInDuration = 1f;
    [Range(0, 20)]
    [Tooltip("Duration of Fade In.")]
    [SerializeField] private float fadeOutDuration = 1f;
    [Range(0, 1)]
    [Tooltip("Alpha value of Fade In. Should be 1f for fully opaque.")]
    [SerializeField] private float fadeInAlphaValue = 1f;
    [Range(0, 1)]
    [Tooltip("Alpha value of Fade Out. Should be 0f for fully transparent.")]
    [SerializeField] private float fadeOutAlphaValue = 0f;

    private void Awake()
    {
        fadeImage = GetComponentInChildren<Image>();
    }

    /// <summary>
    /// Fades In with the preset Defaults
    /// </summary>
    public void fadeIn(MenuController controller)
    {
        //print("fade in called");
        StartCoroutine(FadeInRoutine(controller));
    }

    public void fadeIn()
    {
        //print("fade in called");
        StartCoroutine(FadeInRoutine());
    }

    /// <summary>
    /// Fades out with the preset defaults.
    /// </summary>
    public void fadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }

    public void fadeInText()
    {
        //print("fade in called");
        StartCoroutine(FadeInTextRoutine());
    }

    /// <summary>
    /// Fades out with the preset defaults.
    /// </summary>
    public void fadeOutText()
    {
        StartCoroutine(FadeOutTextRoutine());
    }

    IEnumerator FadeInRoutine(MenuController controller)
    {
        //print("fade in routine");
        Tween tween = fadeImage.DOFade(fadeInAlphaValue, fadeInDuration);
        yield return tween.WaitForCompletion();
        controller.loadScene();
        //print("fade in complete");
    }

    IEnumerator FadeInRoutine()
    {
        //print("fade in routine");
        Tween tween = fadeImage.DOFade(fadeInAlphaValue, fadeInDuration);
        yield return tween.WaitForCompletion();
        //print("fade in complete");
    }

    IEnumerator FadeOutRoutine()
    {
        Tween tween = fadeImage.DOFade(fadeOutAlphaValue, fadeOutDuration).Play();
        yield return tween.WaitForCompletion();
    }

    IEnumerator FadeInTextRoutine()
    {
        //print("fade in routine");
        Tween tween = fadeText.DOFade(fadeInAlphaValue, fadeInDuration);
        yield return tween.WaitForCompletion();
        //print("fade in complete");
    }

    IEnumerator FadeOutTextRoutine()
    {
        Tween tween = fadeText.DOFade(fadeOutAlphaValue, fadeOutDuration).Play();
        yield return tween.WaitForCompletion();
    }


    public void setImage(Image image) {
        fadeImage = image;
    }


    public void setText(TextMeshProUGUI text)
    {
        fadeText = text;
    }
}
