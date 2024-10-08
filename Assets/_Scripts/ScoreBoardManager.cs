using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    public TMP_Text highScoreText, currentScoreText;
    public float highscore;
    public float currentScore;
    public PlayerController characterReference;
    void Start()
    {
        currentScore = PlayerPrefs.GetInt("Score", 0);
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = ($"" + PlayerPrefs.GetInt("HighScore"));
        currentScoreText.text = ("" + PlayerPrefs.GetInt("Score"));
    }

    private void SlowUpdate()
    {
        SetNewHighscore();
    }

    public void SetNewHighscore()
    {
        if (currentScore > highscore)
        {
            highscore = currentScore;
        }
    }
}