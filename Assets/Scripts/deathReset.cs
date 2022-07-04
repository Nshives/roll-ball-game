using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class deathReset : MonoBehaviour
{
    public bool cameraReset = false;
    public float timeElapsed = 0;
    public TextMeshProUGUI timeText;
   

    private Vector3 resetPosition;
    private Rigidbody rb;
    private Vector3 resetVelocity;
    private Vector3 resetAngularVelocity;
    private Vector3 resetRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        resetVelocity = rb.velocity;
        resetAngularVelocity = rb.angularVelocity;
        resetPosition = transform.position;
        resetRotation = transform.eulerAngles;
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name.Contains("Obstacle"))
        {
            rb.velocity = resetVelocity;
            rb.angularVelocity = resetAngularVelocity;
            transform.eulerAngles = resetRotation;
            transform.position = resetPosition;
            cameraReset = true;

            timeElapsed = 0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
  
        if (col.gameObject.name == "EndPoint")
            {
            rb.velocity = resetVelocity;
            rb.angularVelocity = resetAngularVelocity;
            transform.eulerAngles = resetRotation;
            transform.position = resetPosition;
            cameraReset = true;

            shareTimeWithMainManager(timeElapsed);
            timeElapsed = 0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        DisplayTime(timeElapsed);
        
        
    }


    void LateUpdate()
    {
        cameraReset = false;
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
   


    void shareTimeWithMainManager(float timeToShare)
    {
        if (mainManager.Instance != null)
        {
            mainManager.Instance.previousTime = timeToShare;
            mainManager.Instance.UpdateBestTime();
            
            Debug.Log(timeToShare);
        }
    }
}


        

    