using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject boneHighlight;
    public GameObject appleHighlight;
    public GameObject carrotHighlight;
    public GameObject steakHighlight;

    bool startScreen = true;

    public GameObject gameplayUI;
    public GameObject startScreenUI;


    // Start is called before the first frame update
    void Start()
    {
        startScreen = true;
        gameplayUI.SetActive(false);
        startScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (startScreen == false)
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

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Time.timeScale = 1f;
            startScreenUI.SetActive(false);
            gameplayUI.SetActive(true);
            boneHighlight.SetActive(true);
            appleHighlight.SetActive(false);
            carrotHighlight.SetActive(false);
            steakHighlight.SetActive(false);
            startScreen = false;
        }


    }
}
