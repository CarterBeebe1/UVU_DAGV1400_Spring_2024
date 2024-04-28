using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;
    public float speed = 5.0f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {   
        // Get vertical input keys
        float forwardInput = Input.GetAxis("Vertical");

        // Move forward or back according to vertical input
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        // Allow power up indicator to follow the player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f);
    }

    // Check for collision
    private void OnTriggerEnter(Collider other)
    {
        // If player collides with power up:
        if (other.CompareTag("Powerup"))
        {
            // Set has power up to true
            hasPowerup = true;

            // Show power up indicator
            powerupIndicator.gameObject.SetActive(true);

            // Destroy power up and start power up count down
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());
        }
    }

    // Power up count down routine
    IEnumerator PowerupCountDownRoutine()
    {
        // Wait seven seconds and then set hasPowerup to false and hide power up indicator
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    //Check for collision
    private void OnCollisionEnter(Collision collision)
    {   
        // If player hits enemy and has power up execute
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // Get enemy's rigid body and add force away from player if player collides with enemy
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
