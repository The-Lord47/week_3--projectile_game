using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        timer += Time.deltaTime;
        if (timer >= 0.5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = 0;
            }
            
        }

        
    }
}
