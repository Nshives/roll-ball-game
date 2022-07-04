using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollSoundEffect : MonoBehaviour
{
    public AudioSource rollSound;
    public GameObject player;

    private Rigidbody playerRigidBody;

    private void Start()
    {
        playerRigidBody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerSpeed = playerRigidBody.velocity.magnitude;
        if (playerSpeed > 0.5)
        {
            if (!rollSound.isPlaying) rollSound.Play();

            rollSound.volume = Mathf.Min(1.0f, playerSpeed / 10.0f);
        }
        else
        {
            rollSound.Stop();
        }
    }
}
