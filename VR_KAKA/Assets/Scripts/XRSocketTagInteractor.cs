using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
    [Tooltip("Only objects with this tag can be snapped into this socket.")]
    public string targetTag;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        // Only allow hover if the object has the correct tag.
        return base.CanHover(interactable) &&
               (interactable.transform.CompareTag(targetTag));
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        // Only allow selection (snapping) if the object has the correct tag.
        return base.CanSelect(interactable) &&
               (interactable.transform.CompareTag(targetTag));
    }
}
