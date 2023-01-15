using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUPlayer
{
    private string playerName;
    private int playerScore = 0;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }
}
