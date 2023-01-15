using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
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

    void GameOver() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);

    void UpdateScore() => playerScoreText.text = player.PlayerScore.ToString();

    
}
