using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpStrength = 18f;
    public float floatStrength = 10f;
    public GameObject player;

    private PlayerController playerController;
    private Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // get the y velocity for easy access
        float yv = rigidBody.velocity.y;
        // make Codey jump when the button is pressed and is on ground
        if (Input.GetButtonDown("Jump") && playerController.onGround)
        {
            rigidBody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
        // if Codey is going up, holding jump will increase force
        if (Input.GetButton("Jump") && !playerController.onGround && yv > 4.0f)
        {
            rigidBody.AddForce(Vector3.up * floatStrength, ForceMode.Force);
        }
    }
}
