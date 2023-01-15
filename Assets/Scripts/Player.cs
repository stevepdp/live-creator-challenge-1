using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string playerName = "Steve";
    [SerializeField] private int playerScore = 0;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = Mathf.Clamp(value, 1, 600); }
    }
    public void IncrementScore() => playerScore++;
}
