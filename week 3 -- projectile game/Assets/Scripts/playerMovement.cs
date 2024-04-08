using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Animator _animator;

    public float moveSpeed = 10f;

    float horizontalInput;
    float verticalInput;

    public float xRange;
    public float zRange;

    public Transform cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets horizontal (left and right) and vertical (up and down) inputs from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //translates the character up, down, and side to side based on the player input from the previous two lines of code

        if (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0)
        {
            transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime);
        }

        _animator.SetBool("isWalking", (horizontalInput != 0) || (verticalInput != 0));

        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.W) == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.S) == true)
        {
            transform.rotation = Quaternion.Euler(0, -135, 0);
        }

        if (Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.W) == true)
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }

        if (Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.W) == true)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }

        if (Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.S) == true)
        {
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }

        //keeps player in bounds
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z > cameraPosition.position[2] + zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, cameraPosition.position[2] + zRange);
        }

        if (transform.position.z < cameraPosition.position[2] - zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, cameraPosition.position[2] - zRange);
        }
    }
}
