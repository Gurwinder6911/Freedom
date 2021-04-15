using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                int nextSceneIndex = ++currentSceneIndex;
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
