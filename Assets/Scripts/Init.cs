using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Start()
    {
        CleanupObjects();
        NextScene();
    }

    void CleanupObjects()
    {
        GameObject[] oldGameManager = GameObject.FindGameObjectsWithTag("GameController");
        GameObject[] oldPlayer = GameObject.FindGameObjectsWithTag("Player");

        if (oldGameManager.Length > 0)
            Destroy(oldGameManager[0]);
        if (oldPlayer.Length > 0)
            Destroy(oldPlayer[0]);
    }

    void NextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
}