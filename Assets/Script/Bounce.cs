using UnityEngine;

public class Bounce : MonoBehaviour
{
	public float bounceForce = 10f;

	public int point = 10;
	private ScoreModel scoreModel;
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			Vector3 normal = collision.contacts[0].normal;
			Vector3 velocity = new Vector3(-normal.x, 0f, -normal.z);
			collision.rigidbody.AddForce(velocity.normalized * bounceForce, ForceMode.VelocityChange);
			scoreModel.AddScore(point);
		}
	}
}

