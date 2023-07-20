using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void GameOver()
    {
        // Oyunun bitiþini yönetme
        Time.timeScale = 0;
    }
}
