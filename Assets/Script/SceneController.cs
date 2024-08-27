using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private string nextStage = "Stage02";
    public void OnTapNextScene()
    {
        SceneManager.LoadScene(nextStage);
    }
    public void OnTapRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
