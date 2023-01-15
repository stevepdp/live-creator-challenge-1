using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;

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

    void Awake()
    {
        EnforceSingleInstance();
    }
    void EnforceSingleInstance()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void IncrementScore() => playerScore++;
}
