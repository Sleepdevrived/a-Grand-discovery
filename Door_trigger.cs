using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_trigger : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private float openDistance = 4f; // Distance to move the door
    [SerializeField] private float moveSpeed = 2f; // Speed of the door movement
    private bool isOpened = false;

    private void OnTriggerEnter(Collider col)
    {
        // Start opening the door if not already opened
        if (!isOpened)
        {
            StartCoroutine(OpenDoor());
        }
    }

    private void OnTriggerStay(Collider col)
    {
        // Keep the door open if the collider is still in the trigger zone
        if (!isOpened)
        {
            StartCoroutine(OpenDoor());
        }
    }

    private void OnTriggerExit(Collider col)
    {
        // Close the door when the collider exits the trigger zone
        if (isOpened)
        {
            StartCoroutine(CloseDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        isOpened = true;
        Vector3 targetPosition = door.transform.position + new Vector3(0, openDistance, 0);

        while (Vector3.Distance(door.transform.position, targetPosition) > 0.01f)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        door.transform.position = targetPosition; // Ensure it reaches the exact position
    }

    private IEnumerator CloseDoor()
    {
        isOpened = false;
        Vector3 targetPosition = door.transform.position - new Vector3(0, openDistance, 0);

        while (Vector3.Distance(door.transform.position, targetPosition) > 0.01f)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        door.transform.position = targetPosition; // Ensure it reaches the exact position
    }
}



