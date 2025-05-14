using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    int playerHealth;
    int points;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Wynik: " + points.ToString();
        healthText.text = "HP: " + playerHealth.ToString();
    }
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }
    public void ReducePlayerHealth(int amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            gameOverPanel.SetActive(true);
            // zatrzymaj grê
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    }
    public void RestartGame()
    {
        // restartuj grê
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
