using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
      // Variables
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = 9.81f;

    private Vector3 moveDirection;
    private bool isJumping;
    private bool grounded;
    private bool isCrouching;
    private float resetSpeed;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        resetSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input for horizontal and vertical movment
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Sprint when the left shift Key is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = 8f;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            movementSpeed = 3f;
            isCrouching = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = resetSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            movementSpeed = resetSpeed;
            isCrouching = false;
        }

        // Move player at movementSeed based on vertical and horizontal input
        controller.Move(transform.forward * verticalInput * movementSpeed * Time.deltaTime);
        controller.Move(transform.right * horizontalInput * movementSpeed * Time.deltaTime);

        // Rotate player with mouse movment
        float h = 3.0f * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);

        // Check if player is grounded and the jump key is pressed
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        // Apply jump force if true
        if (isJumping && grounded && isCrouching == false)
        {
            moveDirection.y = jumpForce;
            isJumping = false;
            grounded = false;
        }

        // Crouch when the left control key is pressed
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.height = 1.2f;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height = 2f;
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
