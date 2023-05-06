using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Code inspired by Coco Code on youtube "Points counter, HIGH SCORE and display UI in your game - Score points Unity tutorial
//https://www.youtube.com/watch?v=YUcvy9PHeXs&t=187s&ab_channel=CocoCode 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score ++;
        scoreText.text = score.ToString() + " POINTS";

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
