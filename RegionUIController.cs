using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionUIController : MonoBehaviour
{
    // Assign the UI element(s) to be shown/hidden in the Inspector
    public GameObject uiElement;

    // Ensure that this object has a collider set to "Is Trigger"
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the region is the player (you can change this tag as needed)
        if (other.CompareTag("Player"))
        {
            // Enable the UI element when the player enters the region
            if (uiElement != null)
            {
                uiElement.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the region is the player
        if (other.CompareTag("Player"))
        {
            // Disable the UI element when the player leaves the region
            if (uiElement != null)
            {
                uiElement.SetActive(false);
            }
        }
    }
}

