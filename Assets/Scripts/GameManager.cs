using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public List<CPUPlayer> playerList;

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
        InitCPUPlayers();
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

    void GameOver()
    {
        // Add our player to the CPU Player list to be sorted
        playerList.Add(new CPUPlayer { PlayerName = player.PlayerName, PlayerScore = player.PlayerScore });

        // Sort the list using Linq
        playerList = playerList.OrderByDescending(x => x.PlayerScore).ToList();

        // Log it out
        /*foreach (var player in playerList)
        {
            Debug.Log(player.PlayerName + " : " + player.PlayerScore.ToString() + ".\n");
        }*/     

        // Go to leaderboard
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    void InitCPUPlayers()
    {
        playerList = new List<CPUPlayer>
        {
            new CPUPlayer { PlayerName = "Jake", PlayerScore = 80 },
            new CPUPlayer { PlayerName = "Mark", PlayerScore = 70 },
            new CPUPlayer { PlayerName = "Callum", PlayerScore = 65 },
            new CPUPlayer { PlayerName = "Alexia", PlayerScore = 60 },
            new CPUPlayer { PlayerName = "Leia", PlayerScore = 55 },
            new CPUPlayer { PlayerName = "Sidney", PlayerScore = 50 },
            new CPUPlayer { PlayerName = "Eden", PlayerScore = 40 },
            new CPUPlayer { PlayerName = "Bob", PlayerScore = 20 },
            new CPUPlayer { PlayerName = "Violet", PlayerScore = 10 }
        };
    }

    void UpdateScore() => playerScoreText.text = player.PlayerScore.ToString();
}
