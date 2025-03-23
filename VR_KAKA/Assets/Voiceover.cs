using UnityEngine;
using UnityEngine.UI;

public class Voiceover : MonoBehaviour
{
    public Button playButton;
    public AudioSource audioSource;

    private void Start()
    {
        playButton.onClick.AddListener(PlayVoiceover);
    }

    public void PlayVoiceover()
    {  // <-- Ensure it's public
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
