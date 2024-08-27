using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScoreModel : MonoBehaviour
{

    [SerializeField] private float leftTime = 30;

    public Action<int> UpdateScore = _ => { };
    public Action<float> UpdateTime = _ => { };
    public Action<int, float, int> UpdateResult = (_,_,_) => { };
    private int score = 0;
    private int highScore = 0;
    public int Score => score;
    public int HighScore => highScore;
    public float LeftTime => leftTime;
    private void Start()
    {
        UpdateScore(score);
        GameEvent.Instance.OnBrokenAll += () =>
        {
            UpdateResult(score,leftTime, highScore);
        };
    }
    private void Update()
    {
        if (GameStateManager.Instance.GetState == GameStateManager.GameState.InGame)
        {
            leftTime -= Time.deltaTime;
            UpdateTime(leftTime);
            if (leftTime <= 0)
            {
                GameEvent.Instance.OnGameOver();
            }
        }
    }
    public void AddScore(int point)
    {
        score += point;
        UpdateScore(score);
    }
    public void SetHighScore(int highScore) => this.highScore = highScore;
}
