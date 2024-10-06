using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    private int manager;
 
    public MonoBehaviour Player_movement; 

    void Start()
    {
        // Initialize to use camera1 by default
        manager = 0;
        ManageCamera();
    }

    void Update()
    {
        // Check for button press (e.g., "C" key)
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCamera();
        }
    }

    public void ChangeCamera()
    {
        ManageCamera();
    }

    private void ManageCamera()
    {
        if (manager == 0)
        {
            ActivateCamera(camera2);
            manager = 1; // Switch to camera2
            LockPlayerMovement(true); // Lock movement
        }
        else
        {
            ActivateCamera(camera1);
            manager = 0; // Switch to camera1
            LockPlayerMovement(false); // Unlock movement
        }
    }

    private void ActivateCamera(GameObject cameraToActivate)
    {
        camera1.SetActive(cameraToActivate == camera1);
        camera2.SetActive(cameraToActivate == camera2);
        UpdateCursorVisibility();
    }

    private void UpdateCursorVisibility()
    {
        if (manager == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void LockPlayerMovement(bool lockMovement)
    {
        if (Player_movement != null)
        {
            Player_movement.enabled = !lockMovement; // Disable movement when locking
        }
    }
}



