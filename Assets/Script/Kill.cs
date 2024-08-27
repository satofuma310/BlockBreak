using UnityEngine;

public class Kill : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			Destroy(collision.gameObject);
			GameEvent.Instance.OnKillBall();
		}
	}
}
