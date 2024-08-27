using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
	private int brokenObjectCount;
	private int ballCount = 3;
	public int BallCount => ballCount;

	private void Awake()
    {
		brokenObjectCount = FindObjectsOfType<Broken>().Length;


		GameEvent.Instance.OnKillBall += () =>
        {
			ballCount--;

			if (ballCount > 0)
			{
				GameObject newBall = Instantiate(ballPrefab);
				newBall.name = ballPrefab.name;
			}
			else
			{
				GameStateManager.Instance.OutGame();
				GameEvent.Instance.OnGameOver();
			}
		};
		GameEvent.Instance.OnBroken += () =>
		{
			brokenObjectCount--;
			if(brokenObjectCount <= 0)
            {
				GameStateManager.Instance.OutGame();
				GameEvent.Instance.OnBrokenAll();
			}
		};

	}
}
