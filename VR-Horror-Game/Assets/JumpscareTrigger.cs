using UnityEngine;
using System.Collections;

public class JumpscareTrigger : MonoBehaviour
{
    public GameObject jumpscareImageObject;
    public CanvasGroup jumpscareCanvasGroup;
    public AudioSource screamAudio;
    public float fadeDuration = 0.3f; // How fast image fades in/out
    public float shakeDuration = 0.5f; // How long image shakes
    public float shakeIntensity = 30f; // How strong the shake
    public float totalDuration = 1.3f; // Total time before hiding again

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(PlayJumpscare());
        }
    }

    private IEnumerator PlayJumpscare()
    {
        Debug.Log("JUMPSCARE STARTED!");
        // Enable UI object
        jumpscareImageObject.SetActive(true);

        // Reset transparency
        jumpscareCanvasGroup.alpha = 0f;

        // Play scream
        screamAudio.Play();

        // Fade in
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            jumpscareCanvasGroup.alpha = t / fadeDuration;
            yield return null;
        }
        jumpscareCanvasGroup.alpha = 1f;

        // Shake the image
        StartCoroutine(ShakeImage(shakeDuration));

        // Wait until full duration finished
        yield return new WaitForSeconds(totalDuration);

        // Fade out
        t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            jumpscareCanvasGroup.alpha = 1f - (t / fadeDuration);
            yield return null;
        }

        jumpscareCanvasGroup.alpha = 0f;

        // Disable after done
        jumpscareImageObject.SetActive(false);
    }

    private IEnumerator ShakeImage(float duration)
    {
        RectTransform rect = jumpscareImageObject.GetComponent<RectTransform>();
        Vector3 originalPos = rect.anchoredPosition;

        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;

            float offsetX = Random.Range(-shakeIntensity, shakeIntensity);
            float offsetY = Random.Range(-shakeIntensity, shakeIntensity);

            rect.anchoredPosition = originalPos + new Vector3(offsetX, offsetY, 0);

            yield return null;
        }

        rect.anchoredPosition = originalPos;
    }

    private void Start() {
    StartCoroutine(PlayJumpscare());
}
}
