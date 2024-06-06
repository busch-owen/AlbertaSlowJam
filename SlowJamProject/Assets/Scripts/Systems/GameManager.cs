using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    private UnityEvent _gameStarted;
    private UnityEvent _gameEnded;
    private UnityEvent _levelCleared;

    private TimeHandler _timeHandler;
    private DirectionalLightHandler _dirLightHandle;
    private MainMenu _mainMenu;
    private ScoreHandler _scoreHandler;  

    public override void Awake()
    {
        base.Awake();
        
        ReassignReferences();
        
        _gameStarted ??= new UnityEvent();
        _gameEnded ??= new UnityEvent();
        _levelCleared ??= new UnityEvent();
        
        _gameStarted.AddListener(_timeHandler.StartCountingTimer);
        _gameEnded.AddListener(_timeHandler.StopCountingTimer);
        _gameStarted.AddListener(_dirLightHandle.StartDayCycle);
        _gameEnded.AddListener(_dirLightHandle.StopDayCycle);
        _gameEnded.AddListener(_scoreHandler.ResetScore);
        _gameStarted.AddListener(_mainMenu.CloseMainMenu);
        _levelCleared.AddListener(_scoreHandler.RaiseQuota);
    }

    public void StartGame()
    {
        _gameStarted.Invoke();
    }

    public void EndGame()
    {
        Debug.Log("Game ended");
        _gameEnded.Invoke();
        if (_scoreHandler.CheckQuota())
        {
            _levelCleared.Invoke();
            Debug.Log("Quota Met");
            return;
        }
        Debug.Log("Level Failed");
        //Reset(); Do this after scene reload
    }

    private void ReassignReferences()
    {
        _timeHandler = FindFirstObjectByType<TimeHandler>();
        _dirLightHandle = FindFirstObjectByType<DirectionalLightHandler>();
        _mainMenu = FindFirstObjectByType<MainMenu>();
        _scoreHandler = FindFirstObjectByType<ScoreHandler>();
    }
}
