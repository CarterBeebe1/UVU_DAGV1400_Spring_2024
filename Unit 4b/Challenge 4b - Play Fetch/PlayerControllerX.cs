using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public bool previousDog = false;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!previousDog)
            {
                StartCoroutine(DogSpawner());
            }
        }
    }
    IEnumerator DogSpawner()
    {
        previousDog = true;
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(0.3f);
        previousDog = false;
        
    }
}
