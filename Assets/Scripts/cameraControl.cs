using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        rb = player.GetComponent<Rigidbody>();
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        //Vector3 ballSpeed = rb.velocity;
        //float ballYaw = Mathf.Atan2(ballSpeed.z, ballSpeed.x);
        //Debug.Log(ballYaw);

        //transform.eulerAngles = new Vector3(
        //    transform.eulerAngles.x,
        //    Mathf.Rad2Deg * ballYaw,
        //    transform.eulerAngles.z
        //);
    }
}
