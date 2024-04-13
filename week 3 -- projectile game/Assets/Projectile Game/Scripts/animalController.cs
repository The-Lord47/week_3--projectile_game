using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class animalController : MonoBehaviour
{
    NavMeshAgent agent;

    public string foodTag;

    gameManager _gm;

    GameObject SFX;
    public string SFXtag;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _gm = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
        SFX = GameObject.FindGameObjectWithTag(SFXtag);
    }

    // Update is called once per frame
    void Update()
    {
        //uses ai to move the animal towards the player
        agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }


    //---------------DETECTS IF THE ANIMAL HAS COME INTO CONTACT WITH ITS RESPECTIVE PROJECTILE---------------
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == foodTag)
        {
            SFX.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            Destroy(other.gameObject);
            _gm.score++;
        }
    }
}
