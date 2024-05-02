using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suction : MonoBehaviour
{
    // Variables
    public float speed = 68.0f;
    private Rigidbody enemyRb;
    private GameObject suctionRadius;
    public GameObject vaccum;
    public GameObject self;
    float maxDistance = 3.0f; // Maximum suction distance
    bool isNear;
    bool destroyDistance;
    float removeDistance = 1.0f; // Distance before object is destroyed
    private GameManager gameManager;

    //Sound
    public AudioClip moneySound;
    private AudioSource DissapearAudio;


    // Start is called before the first frame update
    void Start()
    {
        // Get rigid body component
        enemyRb = GetComponent<Rigidbody>();

        // Get objects
        suctionRadius = GameObject.Find("Suction Radius");
        //vaccum = GameObject.Find("Vaccum");

    }

    // Update is called once per frame
    void Update()
    {
        // Check if orb is at a close enough distance
        float distance = Vector3.Distance(suctionRadius.transform.position, self.transform.position);
        float destroy = Vector3.Distance(vaccum.transform.position, self.transform.position);
        isNear = distance <= maxDistance;
        destroyDistance = destroy <= removeDistance;

        // Look toward the player
        Vector3 lookDirection = (vaccum.transform.position - transform.position).normalized;

        // Add force toward look direction if near enough to suction radius
        if (isNear)
        {
            enemyRb.AddForce(lookDirection * speed);
        }

        if (destroyDistance)
        {
            Destroy(gameObject);
            DissapearAudio.PlayOneShot(moneySound, 1.0f);
        }

        // Destroy orb if it falls off the world
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // If the orb collids with the vaccum, destroy the orb
        if (other.gameObject.CompareTag("Orb"))
        {
            Destroy(self.gameObject);
        } 
    }
}
