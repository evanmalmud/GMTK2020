using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Black Image covering the UI.")]
    [SerializeField] private Image fadeImage = null;
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
    [Header("Test")]
    [Tooltip("Set this boolean to test the fadeIn/Out. Only works in Play Mode.")]
    [SerializeField] private bool testFades = false;
    [Tooltip("Delay between FadeIn and FadeOut.")]
    [SerializeField] private float delayBetweenFades = 5f;

    private void Awake()
    {
        fadeImage = GetComponentInChildren<Image>();
    }

    void Update()
    {
        if(testFades) {
            TestFadeCoroutine();
        }
    }

    /// <summary>
    /// Fades In with the preset Defaults
    /// </summary>
    public void fadeIn()
    {
        fadeImage.DOFade(fadeInAlphaValue, fadeInDuration).Play();
    }

    /// <summary>
    /// Fades out with the preset defaults.
    /// </summary>
    public void fadeOut()
    {
        fadeImage.DOFade(fadeOutAlphaValue, fadeOutDuration).Play();
    }

    IEnumerator TestFadeCoroutine()
    {
        fadeIn();
        yield return new WaitForSeconds(delayBetweenFades);
        fadeOut();
    }
}
