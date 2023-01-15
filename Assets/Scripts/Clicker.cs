using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Player player;

    public void IncrementScore() => player.IncrementScore();
}
