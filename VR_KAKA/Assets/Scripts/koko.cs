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
        grabInteractable.activated.AddListener(ToggleLight);
    }

    private void ToggleLight(ActivateEventArgs args)
    {
        isOn = !isOn;
        artworkLight.enabled = isOn;
    }
}