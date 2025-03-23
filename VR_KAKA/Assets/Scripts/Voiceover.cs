using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Voiceover : MonoBehaviour
{
    public Button playButton;
    public Slider volumeSlider;
    public AudioSource audioSource;
    private bool isFading = false;

    void Start()
    {
        playButton.onClick.AddListener(PlayVoiceover);
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.gameObject.SetActive(false);
    }

    void PlayVoiceover()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            volumeSlider.gameObject.SetActive(true);
            audioSource.volume = volumeSlider.value;
        }
    }

    void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && audioSource.isPlaying)
        {
            StartCoroutine(FadeOutAndPause());
        }
    }

    IEnumerator FadeOutAndPause()
    {
        isFading = true;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime * 0.5f;
            yield return null;
        }
        audioSource.Pause();
        volumeSlider.gameObject.SetActive(false);
        isFading = false;
    }
}
