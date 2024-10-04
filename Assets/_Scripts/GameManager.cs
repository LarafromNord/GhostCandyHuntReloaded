using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText, timerText;
    public GameObject PC;

    public float timeRemaining = 1;
    public bool timerIsRunning = false;

    private CandyController CController;
    public PlayerController PCController;

    void Start()
    {
        UpdateScoreText();
        timerIsRunning = true;
    }

    void Update()
    {
        DisplayTime(timeRemaining);
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time is out");
                timeRemaining = 0;
                timerIsRunning = false;
                PCController.Death();
            }
        }
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = PCController.scorePoints.ToString();
        PlayerPrefs.SetInt("Score", PCController.scorePoints);

        if (PCController.scorePoints > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", PCController.scorePoints);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = $"{minutes}.{seconds}";
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("Loaded Game Scene");
    }

    public void OnQuitGame()
    {
        SceneManager.LoadScene("QuitGameScene");
        Debug.Log("Loaded Quit Game Scene");
    }

    public void OnSettings()
    {
        SceneManager.LoadScene("SettingsScene");
        Debug.Log("Loaded Settings Scene");
    }

    public void OnGoBack()
    {
        SceneManager.LoadScene("MainMenuScene");
        Debug.Log("Loaded Main Menu");
    }

    public void OnExplanation()
    {
        SceneManager.LoadScene("GuideScene");
        Debug.Log("Loaded Guide Scene");
    }
}
