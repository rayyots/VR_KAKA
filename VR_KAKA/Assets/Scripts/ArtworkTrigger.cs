using UnityEngine;

public class ArtworkTrigger : MonoBehaviour
{
    public GameObject infoPanel;
    public Light artworkLight;

    private void Start()
    {
        if (artworkLight != null)
            artworkLight.enabled = false;  // Ensure light starts off
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoPanel.SetActive(true);
            if (artworkLight != null)
                artworkLight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        infoPanel.SetActive(false);
        if (artworkLight != null)
            artworkLight.enabled = false;
    }
}
