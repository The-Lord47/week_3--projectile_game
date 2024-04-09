using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject boneHighlight;
    public GameObject appleHighlight;
    public GameObject carrotHighlight;
    public GameObject steakHighlight;

    // Start is called before the first frame update
    void Start()
    {
        boneHighlight.SetActive(true);
        appleHighlight.SetActive(false);
        carrotHighlight.SetActive(false);
        steakHighlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //---------------PROJECTILE SELECTION---------------
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            boneHighlight.SetActive(true);
            appleHighlight.SetActive(false);
            carrotHighlight.SetActive(false);
            steakHighlight.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            appleHighlight.SetActive(true);
            boneHighlight.SetActive(false);
            carrotHighlight.SetActive(false);
            steakHighlight.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            carrotHighlight.SetActive(true);
            appleHighlight.SetActive(false);
            boneHighlight.SetActive(false);
            steakHighlight.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            steakHighlight.SetActive(true);
            appleHighlight.SetActive(false);
            carrotHighlight.SetActive(false);
            boneHighlight.SetActive(false);
        }




    }
}
