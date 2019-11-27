using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecapMenu : MonoBehaviour
{
    public Text healthLostText;
    public Text scoreText;
    public Text enemiesText;
    public Text highScoreText;
    public Text pointText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int score = HealthDisplay.instance.GetScore();
        int healthLost = HealthDisplay.instance.GetHealthLost();
        int enemiesKilled = HealthDisplay.instance.GetEnemiesKilled();
        int highScore = HealthDisplay.instance.GetHighScore();
        int bonus = 0;
        if (score >= highScore)
        {
            bonus = 10;
        }
        int points = score - healthLost + enemiesKilled + bonus;
        if (points <= 0)
        {
            points = 0;
        }

        scoreText.text = "Score: " + score;
        healthLostText.text = "Health lost: " + healthLost;
        enemiesText.text = "Enemies killed: " + enemiesKilled;
        highScoreText.text = "High score bonus: " + bonus;
        pointText.text = "Points: " + points;
    }

    public void PauseGame()
    {
        HealthDisplay.instance.CheckHighScore();
        Time.timeScale = 0;
    }


}
