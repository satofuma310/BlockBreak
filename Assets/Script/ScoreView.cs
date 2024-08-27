using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class ScoreView : MonoBehaviour
{
    [SerializeField] GameObject resultRoot;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject clearText;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI highScoreUI;

    [SerializeField] TextMeshProUGUI resultScore;
    [SerializeField] TextMeshProUGUI resultTime;
    [SerializeField] TextMeshProUGUI resultLife;
    [SerializeField] TextMeshProUGUI resultTotalScore;


    [SerializeField] BallSpawner ballSpawner;

    public Action<int> UpdateHighScore = _=> { };

    void Start()
    {
        resultRoot.SetActive(false);
        gameOverText.SetActive(false);
        clearText.SetActive(false);
        GameEvent.Instance.OnBrokenAll += () =>
        {
            clearText.SetActive(true);
            
        };
        GameEvent.Instance.OnGameOver += () =>
        {
            gameOverText.SetActive(true);
        };


    }
    public void SetTimeText(float time)
    {
        timerText.text = "Time: " + Mathf.RoundToInt(time);
    }
    void Update()
    {
        if(GameStateManager.Instance.GetState == GameStateManager.GameState.OutGame)
        {
            SetTimeText(0);
        }
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }
    public void ShowResult(int score,float time,int highScore)
    {
        resultRoot.SetActive(true);
        resultScore.text = "Score: " + score;
        resultTime.text = "Time: " + Mathf.RoundToInt(time) + "x 100 = " + Mathf.RoundToInt(time) * 100;
        resultLife.text = "Life: " + ballSpawner.BallCount + "x 500 = " + ballSpawner.BallCount * 500;

        int toralScore = score + Mathf.RoundToInt(time) * 100 + ballSpawner.BallCount * 500;
        resultTotalScore.text = "Total Score: " + toralScore;

        if (highScore < toralScore)
        {
            UpdateHighScore(toralScore);
            highScoreUI.text = "High Score: " + toralScore;
        }
    }
}
