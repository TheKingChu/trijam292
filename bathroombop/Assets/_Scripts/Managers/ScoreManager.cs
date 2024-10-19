using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    private int consecutiveHits = 0;
    private int scoreMultipler = 1;

    private void Start()
    {
        score = 0;
    }

    public void AddPoints(int points)
    {
        consecutiveHits++;
        scoreMultipler = Mathf.Clamp(consecutiveHits, 1, 5);
        score += points * scoreMultipler;
        UpdateScoreText();
    }

    public void ResetMultiplier()
    {
        consecutiveHits = 0;
        scoreMultipler = 1;
    }

    private void UpdateScoreText()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void MissedHit()
    {
        ResetMultiplier();
    }
}
