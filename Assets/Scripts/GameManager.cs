using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] Player player;
    [SerializeField] TMP_Text playerScoreText;
    [SerializeField] TMP_Text timeRemainingText;

    [SerializeField] private float timeRemaining;

    void Awake()
    {
#if UNITY_EDITOR
        timeRemaining = 4f;
#else
        timeRemaining = 60f;
#endif

        EnforceSingleInstance(); 
    }
    void Start()
    {
        StartCoroutine(CountdownTimer());
    }
    void Update()
    {
        UpdateScore();
    }

    IEnumerator CountdownTimer()
    {
        while (timeRemaining > 1)
        {
            timeRemaining -= 1;
            timeRemainingText.text = timeRemaining.ToString();
            yield return new WaitForSeconds(1f);
        }

        timeRemainingText.text = timeRemaining.ToString();
        GameOver();
    }

    void EnforceSingleInstance()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void GameOver() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);

    void UpdateScore() => playerScoreText.text = player.PlayerScore.ToString();

    
}
