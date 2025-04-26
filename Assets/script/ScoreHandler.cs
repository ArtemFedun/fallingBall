using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public int Score;
    private int streakValue;

    [SerializeField] private int scoreBase;
    [SerializeField] private int streakBase;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public void AddScore()
    {
        streakValue += streakBase;
        Score += scoreBase * streakValue;
        scoreText.text = $"SCORE: {Score}";
    }

    public void ResetStreak()
    {
        streakValue = 0;
    }
}