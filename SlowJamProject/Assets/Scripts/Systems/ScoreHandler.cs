using UnityEngine;

public class ScoreHandler : Singleton<ScoreHandler>
{
    private int _currentScore;

    [SerializeField] private float scoreQuota;
    [SerializeField] private float quotaMultiplier;

    private bool _quotaMet;
    
    public void AddToScore(int value)
    {
        _currentScore += value;
    }

    public void ResetScore()
    {
        _currentScore = 0;
    }

    public bool CheckQuota()
    {
        _quotaMet = scoreQuota >= _currentScore;
        return _quotaMet;
    }

    public void RaiseQuota()
    {
        scoreQuota *= quotaMultiplier;
    }
}
