using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30;
    private float bottomLimit = -5;

    GameController _gm;
    GameObject _player;

    private void Start()
    {
        _gm = GameObject.FindGameObjectWithTag("GameController2").GetComponent<GameController>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
            if ( gameObject.tag == "Ball")
            {
                _gm.lives--;
                _player.GetComponent<AudioSource>().Play();

            }
        }

    }
}
