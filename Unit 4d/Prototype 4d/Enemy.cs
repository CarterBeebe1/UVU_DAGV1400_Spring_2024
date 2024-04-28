using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigid body component
        enemyRb = GetComponent<Rigidbody>();

        // Get player object
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Look toward the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Add force toward look direction
        enemyRb.AddForce(lookDirection * speed);

        // Destroy enemy if it falls off the arena
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
