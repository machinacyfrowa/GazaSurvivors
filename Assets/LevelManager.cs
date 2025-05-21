using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pauseMenuPanel;
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuPanel.activeSelf)
                ResumeGame();
            else
                PauseGame();
        }
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
            // zatrzymaj gr�
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    }
    public void RestartGame()
    {
        // restartuj gr�
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
    }
    public void MainMenu()
    {
        //przed powrotem do menu g��wnego
        //gre trzeba odpauzowa�
        Time.timeScale = 1;
        //przechodzimy do menu g��wnego
        //TODO
    }
    public void ExitGame()
    {
        //je�li mieliby�my co� zrobi� przed faktycznym wy�aczeniem gry to
        //b�dzie to w�a�nie w GameManagerze
        GameManager.Instance.ExitGame();
    }
}
