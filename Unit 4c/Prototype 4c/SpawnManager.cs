using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    public PlayerController playerControllerScript;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn obstacal object after start delay and continue spawning at the repeatRate.
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        // Get player controller script
        playerControllerScript = player.GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        // If the game isn't over, continue spawning an obstacle object.
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}