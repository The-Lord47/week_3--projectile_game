using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public int score;

    public TMP_Text score_txt;

    public TMP_Text highscore_txt;

    // Start is called before the first frame update
    void Start()
    {
        highscore_txt.text = "Highscore:" + PlayerPrefs.GetInt("Highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score_txt.text = "Score:" + score;
    }
}
