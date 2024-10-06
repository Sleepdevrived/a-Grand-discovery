using UnityEngine;
using UnityEngine.Events;

public class EndTrigger : MonoBehaviour
{
    public UnityEvent onTriggerEnterEvent;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure your player has the "Player" tag
        {
            // Invoke the event
            onTriggerEnterEvent.Invoke();
        }
    }
}

