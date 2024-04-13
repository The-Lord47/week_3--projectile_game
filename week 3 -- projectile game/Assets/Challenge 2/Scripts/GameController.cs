using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int score = 0;
    public int lives = 3;
    public TMP_Text score_txt;
    public TMP_Text lives_txt;
    public TMP_Text highscore_txt;
    public GameObject gameover;
    public GameObject startText;
    public GameObject GameUI;
    bool gamestart;

    // Start is called before the first frame update
    void Start()
    {
        highscore_txt.text = "Highscore:" + PlayerPrefs.GetInt("Highscore_Challenge").ToString();
        gameover.SetActive(false);
        GameUI.SetActive(false);
        startText.SetActive(true);
        gamestart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestart == false)
        {
            Time.timeScale = 0f;
            if (Input.anyKeyDown)
            {
                gamestart = true;
                Time.timeScale = 1f;
                startText.SetActive(false);
                GameUI.SetActive(true);
            }
        }

        score_txt.text = "Score:" + score;
        lives_txt.text = "Lives:" + lives;

        if(lives == 0)
        {
            gameover.SetActive(true);
            if (score > PlayerPrefs.GetInt("Highscore_Challenge"))
            {
                PlayerPrefs.SetInt("Highscore_Challenge", score);
            }
            Time.timeScale = 0f;
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
