using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Variables
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    public ParticleSystem explosionParticle;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigidbody component and GameManager script
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Add a random upward inpulse force and rotation force for spawned object
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        // Set objects position to a random spawn position
        transform.position = RandomSpawnPos();
    }

    // Trigger when the mouse button is pressed and the cursor is hovering over the game object
    private void OnMouseDown()
    {   
        // If the game is running destroy game object, update score, and add particle effect
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    // Detect collision
    private void OnTriggerEnter(Collider other)
    {
        //If game object falls off screen, destroy the object, and start game over function if objects does not have tag "Bad"
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
        gameManager.GameOver();
        }
    }

    // Function that returns random upward force
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Function that returns a random rotation force
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Function that returns a random location for the object to spawn
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
