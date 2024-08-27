using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] ScoreModel scoreModel;
    [SerializeField] ScoreView scoreView;

    private void Awake()
    {
        scoreModel.UpdateTime += time => scoreView.SetTimeText(time);
        scoreModel.UpdateScore += score => scoreView.SetScoreText(score);
        scoreModel.UpdateResult += (score, time, highScore) => scoreView.ShowResult(score, time,highScore);
    }
}
