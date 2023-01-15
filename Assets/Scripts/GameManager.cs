using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TMP_Text playerScoreText;
    [SerializeField] private float timeRemaining = 60f;

    private void Start()
    {
        StartCoroutine(CountdownTimer());
    }
    private void Update()
    {
        UpdateScore();
    }

    void UpdateScore() => playerScoreText.text = player.PlayerScore.ToString();

    IEnumerator CountdownTimer()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= 1;
            Debug.Log("Time remaining: " + timeRemaining);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("-> to leaderboard");
    }
}
