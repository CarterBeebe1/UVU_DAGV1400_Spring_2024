using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Store components for rigidbody, animator and audio source
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Multiply gravity by gravityModifier amount
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Allow the player to jump if on ground, game isn't over, and the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // Add upward force to player and set isOnGround to false
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            // Play jump animation
            playerAnim.SetTrigger("Jump_trig");

            // Stop dirt particles
            dirtParticle.Stop();

            // Play Jump sound
            playerAudio.PlayOneShot(jumpSound, 0.4f);
        }
    }

    // Execute when player collides with ground
    private void OnCollisionEnter(Collision collision)
    {
        // Set isOnGround to true
        isOnGround = true;

        // Play dirt particle animation if player collides with ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        // Execute if player collides with obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // End the game
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            // Play explosion particle animation and crash sound
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);

            // Stop dirt particle animation
            dirtParticle.Stop();
        }
    }
}
