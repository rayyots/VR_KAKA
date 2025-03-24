using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class koko : MonoBehaviour
{
    public Light artworkLight;
    private bool isOn = false;
    private XRGrabInteractable grabInteractable;
    public AudioSource audioSource;
    public AudioClip lightToggleSound;  // Single sound for both ON and OFF
    public AudioClip grabSound;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.activated.AddListener(ToggleLight);  // Press button to toggle light
            grabInteractable.selectEntered.AddListener(PlayGrabSoundAndTurnOffLight);  // Play grab SFX & turn off light
        }

        if (artworkLight != null)
        {
            artworkLight.enabled = isOn; // Ensure initial light state
        }
    }

    public void ToggleLight(ActivateEventArgs args)
    {
        isOn = !isOn;  // Toggle state
        artworkLight.enabled = isOn;

        // Play the same sound for both light ON and OFF
        if (audioSource && lightToggleSound)
        {
            audioSource.PlayOneShot(lightToggleSound);
        }
    }

    public void PlayGrabSoundAndTurnOffLight(SelectEnterEventArgs args)
    {
        // Always play grab sound
        if (audioSource && grabSound)
        {
            audioSource.PlayOneShot(grabSound);
        }

        // If the light is ON, turn it OFF when grabbed
        if (isOn)
        {
            isOn = false;
            artworkLight.enabled = false;

            // Play the same light toggle sound
            if (audioSource && lightToggleSound)
            {
                audioSource.PlayOneShot(lightToggleSound);
            }
        }
    }
}
