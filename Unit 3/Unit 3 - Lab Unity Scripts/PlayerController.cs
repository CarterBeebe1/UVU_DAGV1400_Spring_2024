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
    // Player control function parameters
    private CharacterController controller;
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = 9.81f;

    private Vector3 moveDirection;
    private bool isJumping;
    private bool grounded;
    private bool isCrouching;
    private float resetSpeed;

    // Stamina main parameters
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [SerializeField] private float jumpCost = 20;
    [HideInInspector] private bool hasRegenerated = true;
    [HideInInspector] private bool weAreSpriniting = false;

    // Stamina regen parameters
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

    // Stamina speed parameters
    [SerializeField] private int slowedRunSpeed = 5f;
    [SerializeField] private int normalRunSpeed = 8f;

    //Stamina UI Elements
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    private FirstPersonControllerCustom PlayerController;


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

        // Sprint when the left shift Key is pressed and elapseTime > 0
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (elapseTime == 0)
            {
                tired = true;
            }
            if (elapseTime > 0 && tired == false)
            {
                elapseTime = -60;
                movementSpeed = resetSpeed;
            }
            if (elapseTime < 0)
            {
                movementSpeed = 8f;
            }
        }

        // Add one to elapseTime to track how long its been
        elapseTime = elapseTime + 1;

        //When player becomes tired and elapseTime is set to 0, wait 120 updates before setting tired to false
        if (elapseTime == 120)
        {
            tired = false;
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
    }
}
