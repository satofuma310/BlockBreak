using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene("Stage01");
	}
}
