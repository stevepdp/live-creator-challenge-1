using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] TMP_Text leaderboardText;

    [SerializeField] GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Start()
    {
        ReadoutPlayers();
    }

    void ReadoutPlayers()
    {
        foreach (var player in gameManager.playerList)
        {
            leaderboardText.text += "";

            leaderboardText.text += player.PlayerName + " : " + player.PlayerScore.ToString() + ".\n";
        }
    }
}
