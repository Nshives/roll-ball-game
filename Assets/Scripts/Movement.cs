using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
    {
    public float speed;
    public GameObject cameraTracker;
    private Rigidbody rb;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float cameraYaw = Mathf.Deg2Rad * (-cameraTracker.transform.eulerAngles.y + 90);


        float joystickLeftRight = 0.0f; // Input.GetAxis("Horizontal");
        float joystickForwardAft = Input.GetAxis("Vertical");
        float joystickYaw = Mathf.Atan2(joystickForwardAft, joystickLeftRight);
        joystickYaw += Mathf.Deg2Rad * -90;
        float joystickHypotenuse = Mathf.Sqrt(joystickForwardAft * joystickForwardAft + joystickLeftRight * joystickLeftRight);

        float combinedYaw = cameraYaw + joystickYaw;

        float moveHorizontal = Mathf.Cos(combinedYaw);
        float moveVertical = Mathf.Sin(combinedYaw);
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movement * speed * joystickHypotenuse);
  
    }
}


        