using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    // Robot control Variable Parameters
    [SerializeField] private float movementSpeed = 240f;
    private bool grounded = true;
    Rigidbody m_Rigidbody;
    public GameObject cameraFollow;
    public float rotateSpeed = 2.0f;
    private Vector3 resetPos;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Move backward when the W key is pressed
        if (Input.GetKey("w") && grounded)
        {
            m_Rigidbody.velocity = transform.forward * movementSpeed * Time.deltaTime;
        }

        // Move backward when the S key is pressed
        if (Input.GetKey("s") && grounded)
        {
            m_Rigidbody.velocity = transform.forward * -movementSpeed * Time.deltaTime;
        }

        float mouseValue = rotateSpeed * Input.GetAxis("Mouse X");
         transform.Rotate(0, mouseValue, 0);

         // Reset player position if they fall off the world
        if (transform.position.y < -4)
        {
            transform.position = resetPos;
            grounded = true;
        }

        if (transform.position.x > 16 || transform.position.y < -16)
        {
            grounded = false;
        }

        if (transform.position.z > 16 || transform.position.z < -16)
        {
            grounded = false;
        }
    }

    void LateUpdate()
    {
    // Camera follows the players position
    cameraFollow.transform.position = transform.position + new Vector3(0, 5.4f, -7.0f);
    }
}
