using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TMP_Text playerScoreText;
    [SerializeField]
    private float timeRemaining;

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

    void UpdateScore() => playerScoreText.text = player.PlayerScore.ToString();

    IEnumerator CountdownTimer()
    {
        while (timeRemaining > 1)
        {
            timeRemaining -= 1;
            Debug.Log("Time remaining: " + timeRemaining);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("-> to leaderboard");
    }
}
