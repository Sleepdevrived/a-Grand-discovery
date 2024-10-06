using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Include this for UI elements

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f; // Distance to interact with boxes
    public float pushPullForce = 5f; // Force applied to the box
    public LayerMask boxLayer; // Layer for the boxes

    public GameObject holdingIndicator; // Reference to the UI element for holding indication

    private Rigidbody currentBox;

    void Start()
    {
        // Ensure the holding indicator is initially hidden
        if (holdingIndicator != null)
        {
            holdingIndicator.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentBox == null)
            {
                TryPickUpBox();
            }
            else
            {
                ReleaseBox();
            }
        }

        if (currentBox != null)
        {
            MoveBox();
        }

        // Show or hide the holding indicator based on whether a box is held
        if (holdingIndicator != null)
        {
            holdingIndicator.SetActive(currentBox != null);
        }
    }

    private void TryPickUpBox()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, boxLayer))
        {
            if (hit.rigidbody != null)
            {
                currentBox = hit.rigidbody;
            }
        }
    }

    private void MoveBox()
    {
        float distance = Vector3.Distance(transform.position, currentBox.position);

        // Only allow pushing/pulling if the distance is within the interaction distance
        if (distance < interactionDistance)
        {
            Vector3 direction = (transform.position - currentBox.position).normalized;

            if (Input.GetKey(KeyCode.W))
            {
                currentBox.AddForce(-direction * pushPullForce);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                currentBox.AddForce(direction * pushPullForce);
            }
        }
    }

    private void ReleaseBox()
    {
        currentBox = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * interactionDistance);
    }
}




