using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int healthLost = 0;
    public int enemiesKilled = 0;
    public int maxHealth = 2;
    public int health = 2;
    public int score = 1;
    public Text healthText;
    public Text scoreText;
    public static HealthDisplay instance;

    public GameObject recapUi;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        score = 1;
        if (instance == null)
        {
            instance = this;
        }
        enemiesKilled = 0;
        healthLost = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH: " + health;
        scoreText.text = "SCORE: " + score;
        // healthText.text = "HEALTH: " + health.ToString();
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     health--;
        // }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        recapUi.SetActive(true);
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
    }
    public void SubstractScore(int scoreValue)
    {
        score -= scoreValue;
        if (score < 0)
        {
            score = 0;
        }
    }
    public void SetScore(int scoreValue)
    {
        score = scoreValue;
    }
    public int GetScore()
    {
        return score;
    }
    public void AddHealth(int healthValue)
    {
        health += healthValue;
        if (health > maxHealth)
        {
            health = healthValue;
        }
    }
    public void SubstractHealth(int healthValue)
    {
        health -= healthValue;
        if (health < 0)
        {
            health = 0;
        }
        healthLost++;
    }
    public int GetHealth()
    {
        return health;
    }
    public bool IsMaxHealth()
    {
        return (health >= maxHealth);
    }
    public void AddEnemyKilled()
    {
        enemiesKilled++;
    }
    public int GetHealthLost()
    {
        return healthLost;
    }
    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
    public void SetHighScore(int highScore)
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }
    public void CheckHighScore()
    {
        int highScore = GetHighScore();
        if (score > highScore)
        {
            SetHighScore(score);
        }
    }
}
