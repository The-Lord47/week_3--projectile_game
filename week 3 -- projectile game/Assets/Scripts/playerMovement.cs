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

    public GameObject[] projectiles;
    public Transform projectileParent;

    public GameObject Greying;
    public GameObject GameOver;

    private int projectileSelection = 0;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //---------------MOVES THE CHARACTER AROUND THE ENVIRONMENT---------------

        //gets horizontal (left and right) and vertical (up and down) inputs from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //updates the character's position based on the input
        transform.position += moveSpeed * horizontalInput * Time.deltaTime * new Vector3(1, 0, 0);
        transform.position += moveSpeed * verticalInput * Time.deltaTime * new Vector3(0, 0, 1);


        //---------------RELAYS TO THE ANIMATOR THAT THE CHARACTER IS WALKING---------------

        //tells the animator when the player is moving
        _animator.SetBool("isWalking", (horizontalInput != 0) || (verticalInput != 0));


        //---------------ANGLES THE CHARACTER TO THE MOUSE-----------------------

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        //rotates the character accordingly
        transform.rotation = Quaternion.Euler(new Vector3(0f, -90 - angle, 0f));


        //---------------KEEPS THE PLAYER IN BOUNDS---------------
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

        //---------------PROJECTILE SELECTION---------------

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            projectileSelection = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            projectileSelection = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            projectileSelection = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            projectileSelection = 3;
        }


        //---------------PROJECTILE SPAWNING SYSTEM---------------

        //spawns a projectile when space is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPos = transform.position + new Vector3(0,2,0);
            GameObject tempObject = Instantiate(projectiles[projectileSelection], spawnPos, transform.rotation, projectileParent);
            //destroys the projectile after a certain amount of time
            Destroy(tempObject, 3);
        }
    }

    //---------------CALCULATES ANGLES BETWEEN VECTORS---------------
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dog" || other.tag == "Fox" || other.tag == "Moose" || other.tag == "Horse")
        {
            Time.timeScale = 0f;
            Greying.SetActive(true);
            GameOver.SetActive(true);
        }
    }
}
