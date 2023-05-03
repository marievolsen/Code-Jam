using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Code inspired by Coco Code on youtube "Points counter, HIGH SCORE and display UI in your game - Score points Unity tutorial
//https://www.youtube.com/watch?v=YUcvy9PHeXs&t=187s&ab_channel=CocoCode 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager control;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    int score = 0;
    int highscore = 0;
   
    private void Awake ()
    {
        control = this;

        if (control == null)
        {
            control = this;
            DontDestroyOnLoad(this.gameObject);
        }
       

        else if (control != this)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
