using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;

    public PlayerShip player;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        lifeText.text = player.health.ToString();
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
