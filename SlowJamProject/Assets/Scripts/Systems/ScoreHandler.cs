using TMPro;
using UnityEngine;

public class ScoreHandler : Singleton<ScoreHandler>
{
    public int CurrentScore { get; private set; }

    [field: SerializeField] public float ScoreQuota { get; private set; }
    [SerializeField] private float quotaMultiplier;

    private bool _quotaMet;
    
    public void AddToScore(int value)
    {
        CurrentScore += value;
        Debug.Log(CurrentScore);
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }

    public bool CheckQuota()
    {
        _quotaMet = ScoreQuota >= CurrentScore;
        return _quotaMet;
    }

    public void RaiseQuota()
    {
        ScoreQuota *= quotaMultiplier;
    }
}
