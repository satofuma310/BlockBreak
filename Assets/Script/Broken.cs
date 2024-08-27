using UnityEngine;

public class Broken : MonoBehaviour
{
	[SerializeField] private ScoreModel scoreModel;
	public int point = 100;
    private void Start()
    {
		scoreModel = FindAnyObjectByType<ScoreModel>();
	}
    private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			Destroy(gameObject);
			scoreModel.AddScore(point);
			GameEvent.Instance.OnBroken();
		}
	}
}
