using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    GameController _gm;
    GameObject dogBarkSFX;

    private void Start()
    {
        _gm = GameObject.FindGameObjectWithTag("GameController2").GetComponent<GameController>();
        dogBarkSFX = GameObject.FindGameObjectWithTag("dogSFX");
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        _gm.score++;
        dogBarkSFX.GetComponent<AudioSource>().Play();
    }
}
