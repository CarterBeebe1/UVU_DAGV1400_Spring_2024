using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnTimer;
    private int spawnIntervalLower = 1;
    private int spawnIntervaUpper = 5;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = startDelay;
        currentTime = Time.time;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnRandomBall();
            spawnTimer = Random.Range(spawnIntervalLower, spawnIntervaUpper + 1);
        }
    }

    void SpawnRandomBall()
    {
        int randomNum = UnityEngine.Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        Instantiate(ballPrefabs[randomNum], spawnPos, ballPrefabs[randomNum].transform.rotation);
    }
}