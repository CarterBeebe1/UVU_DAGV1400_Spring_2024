using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Variable for rotation speed
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        // Get input for horzontal keys
        float horizontalInput = Input.GetAxis("Horizontal");

        // Rotate at rotation speed according to horizontalInput
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
