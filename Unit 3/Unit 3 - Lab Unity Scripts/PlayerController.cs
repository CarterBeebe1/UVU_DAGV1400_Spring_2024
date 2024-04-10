using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    private float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isJumping;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input for horizontal and vertical movment
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move player at movementSeed based on vertical and horizontal input
        controller.Move(Vector3.forward * verticalInput * movementSpeed * Time.deltaTime);
        controller.Move(Vector3.right * horizontalInput * movementSpeed * Time.deltaTime);

        // Check if player is grounded and the jump key is pressed
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        // Apply jump force if true
        if (isJumping && grounded)
        {
            moveDirection.y = jumpForce;
            isJumping = false;
            grounded = false;
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        // Reset moveDirection to zero and grounded to true if character is grounded
        if (controller.isGrounded)
        {
            moveDirection.y = 0;
            grounded = true;
        }
    }
}
