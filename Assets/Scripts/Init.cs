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

        if (oldGameManager.Length > 0)
            Destroy(oldGameManager[0]);
    }

    void NextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
}