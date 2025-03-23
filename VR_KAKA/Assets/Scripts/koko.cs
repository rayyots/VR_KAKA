using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class koko : MonoBehaviour
{
    public Light artworkLight;
    private bool isOn = false;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.activated.AddListener(ToggleLight);  // Press button to toggle
            grabInteractable.selectEntered.AddListener(Grabbed);  // When grabbing, turn off
        }

        if (artworkLight != null)
        {
            artworkLight.enabled = isOn; // Ensure initial state
        }
    }

    public void ToggleLight(ActivateEventArgs args)
    {
        isOn = !isOn;
        artworkLight.enabled = isOn;
    }

    public void Grabbed(SelectEnterEventArgs args)
    {
        isOn = false;
        artworkLight.enabled = false;
    }
}
