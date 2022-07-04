using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public float speedH = 0.5f; // Scalar for overall rotation speed. Try changing others before this.
    public float speedV = 5.0f;
    public float accelYaw = 0.1f; // For every tap on an arrow key, how much force to apply to camera rotation
    public float dragCoeff = 0.06f; // How quickly camera should stop spinning after arrow keys are released

    private float yaw;
    private float yawVelocity;
    private float pitch;

    public deathReset script;

    // Start is called before the first frame update
    void Start()
    {
        yaw = 0.0f;
        yawVelocity = 0.0f;
        pitch = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //float w = Screen.height;
        //float h = Screen.width;

        //Vector3 mousePos = Input.mousePosition;
        //float mouseX = mousePos.x - w / 2;
        //float mouseY = mousePos.y - h / 2;

        //yaw += speedH * mouseX;
        //pitch -= speedV * mouseY;

        //if (pitch >= 15)
        //{
        //    pitch = 15;
        //}
        //else if (pitch <= -12)
        //{
        //    pitch = -12;
        //}


        // If mouse is clicked, allow dragging to modify the pitch of the camera
        if (Input.GetMouseButton(0))
        {
            pitch -= speedV * Input.GetAxis("Mouse Y");
        }

        // Allow left/right arrow keys to adjust camera yaw
        //yaw += speedH * Input.GetAxis("Horizontal"); //Input.GetAxis("Mouse X");
        yawVelocity += accelYaw * Input.GetAxis("Horizontal");
        yawVelocity += -Mathf.Sign(yawVelocity) * yawVelocity * yawVelocity * dragCoeff;
        yaw += speedH * yawVelocity;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (script.cameraReset == true)
        {
            yaw = 0.0f;
            pitch = 0.0f;
        }

    }
    
}
    