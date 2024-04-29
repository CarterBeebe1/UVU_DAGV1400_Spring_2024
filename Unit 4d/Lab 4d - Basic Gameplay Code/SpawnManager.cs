using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn wave of enemys
        SpawnEnemyWave(waveNumber);

        // Generate power up
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Store the current number of enemys in enemyCount
        enemyCount = FindObjectsOfType<Suction>().Length;

        // Check if all enemys have fallen out of arena
        if (enemyCount == 0)
        {   
            // Add one to waveNumber and spawn enemy amount accourding to waveNumber
            waveNumber++;
            SpawnEnemyWave(waveNumber);

            // Spawn power up
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    // Function to spawn enemies according to wave number
    void SpawnEnemyWave(int enemiesToSpawn)
    {  
        for(int i = 0; i < enemiesToSpawn; i ++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Function to spawn enemies in a random position on the arena
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
