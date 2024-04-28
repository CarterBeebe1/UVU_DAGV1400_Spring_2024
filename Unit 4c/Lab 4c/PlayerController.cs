/*
Description:
This script allows the player to move the character and rotate it using the mouse.
It also allows the player to crouch, jump, and sprint.
*/

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Player control variable parameters
    private CharacterController controller;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 9.81f;

    private Vector3 moveDirection;
    private bool isJumping;
    private bool grounded;
    private bool isCrouching;
    private bool isSprinting = false;
    private float resetSpeed;
    [HideInInspector] public StaminaController _staminaController;
    private Vector3 resetPos;

    // Start is called before the first frame update
    void Start()
    {
        _staminaController = GetComponent<StaminaController>();
        controller = GetComponent<CharacterController>();

        // Set the players resetSpeed to the current movementSpeed
        resetSpeed = movementSpeed;

        // Set the players resetPos to starting position
        resetPos = transform.position;
    }
    
    // Sets player movement speed based on value in StaminaController
    public void SetRunSpeed(float speed)
    {
        movementSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input for horizontal and vertical movment
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Sprint when the left shift Key is pressed and elapseTime > 0
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
            if (verticalInput != 0 || horizontalInput != 0)
            {
                isSprinting = true;
            }
        }

        // Check if player is sprinting and activate sprinting function in StaminaController script if true
        if (_staminaController.playerStamina > 0 && isSprinting)
        {
            _staminaController.weAreSpriniting = true;
            _staminaController.Sprinting();
        }
        
        // Set movement speed to 3 if crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            movementSpeed = 3f;
            isCrouching = true;
        }

        // If player releases left shift key set sprinting values to false and set movment speed to normal
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = resetSpeed;
            isSprinting = false;
            _staminaController.weAreSpriniting = false;
        }

        // If player is not sprinting and stamina is greater than 0, set weAreSprinting to false
        if (!isSprinting)
        {
            if(_staminaController.playerStamina > 0)
            {
                _staminaController.weAreSpriniting = false;
            }
        }

        // Set movment speed to normal after crouching and set isCrouching to false.
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
            if (isCrouching == false)
            {
                isJumping = true;
            }
        }

        // Apply jump force if true
        if (isJumping && grounded)
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

        // Reset player position if they fall off the world
        if (transform.position.y < -50)
        {
            transform.position = resetPos;
        }
    }
}
