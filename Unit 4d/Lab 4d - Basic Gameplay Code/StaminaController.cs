/*
Description:
This script defines a stamina bar that depletes when the player is sprinting.
The player will stop sprinting when the stamina bar depletes completely.
The stamina bar is hidden when the player isn't sprinting.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    // Stamina main parameters
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool weAreSpriniting = false;

    // Stamina speed parameters
    [SerializeField] private int walkSpeed = 5;


    // Stamina regen parameters
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

    //Stamina UI Elements
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    private PlayerController playerController;

    // Get playerController component
    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        // Hide the mouse cursor
        Cursor.visible = false;
    }

    // Update every frame
    private void Update()
    {
        // Execute if player is not sprinting
        if (!weAreSpriniting)
        {
            // Regenerate stamina until it is full
            if (playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina(1);

                // Show stamina bar while regnerating and set hasRegenerated to true
                if (playerStamina >= 1)
                {
                    sliderCanvasGroup.alpha = 1;
                    hasRegenerated = true;
                }

                // Hide stamina bar when stamina is full
                if (playerStamina >= maxStamina)
                {
                    sliderCanvasGroup.alpha = 0;
                }
            }
        }
    }

    // Function that drians stamina when player is sprinting and stops player from sprinting when stamina reaches 0
    public void Sprinting()
    {
        if (hasRegenerated)
        {
            weAreSpriniting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);

            // If player stamina is out of stamina, set to walk speed and remove stamina bar
            if(playerStamina <= 0)
            {
                hasRegenerated = false;
                playerController.SetRunSpeed(walkSpeed);
                sliderCanvasGroup.alpha = 0;
            }
        }
    }


    // Fill and empty stamina bar depending on the amount of stamina the player has.
    void UpdateStamina(int value)
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;

        if (value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }
}
