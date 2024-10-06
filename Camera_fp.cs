using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_fp : MonoBehaviour
{


    public float MouseX;
    public float MouseY;

    public Transform Body;
    public Transform Head;

    public float Angle;

    // Start is called before the first frame update
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        MouseX = Input.GetAxis("Mouse X") * 80 * Time.deltaTime;
        Body.Rotate(Vector3.up, MouseX);

        MouseY = Input.GetAxis("Mouse Y") * 80 * Time.deltaTime;
        Angle -= MouseY;
        Angle = Mathf.Clamp(Angle, -5, 40);
        Head.localRotation = Quaternion.Euler(Angle, 0, 0);
    }
}

