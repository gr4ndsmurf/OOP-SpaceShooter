using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI inGameScoreText;
    public TextMeshProUGUI lifeText;

    public TextMeshProUGUI gameOverScoreText;

    public PlayerShip player;

    public GameObject inGameCanvas;
    public GameObject gameOverCanvas;
    private void Start()
    {
        Time.timeScale = 1;
        inGameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
    }

    private void Update()
    {
        inGameScoreText.text = score.ToString();
        lifeText.text = player.health.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScoreText.text = score.ToString();
        inGameCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
