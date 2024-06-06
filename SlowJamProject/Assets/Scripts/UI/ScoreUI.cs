using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private ScoreHandler _scoreHandler;

    private void Awake()
    {
        _scoreHandler = FindFirstObjectByType<ScoreHandler>();
    }

    private void FixedUpdate()
    {
        scoreText.text = $"Score: {_scoreHandler.CurrentScore}/{_scoreHandler.ScoreQuota}";
    }
}
