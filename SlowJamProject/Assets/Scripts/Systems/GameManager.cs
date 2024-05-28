using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private UnityEvent _gameStarted;

    private TimeHandler _timeHandler;
    private DirectionalLightHandler _dirLightHandle;

    private void Awake()
    {
        _timeHandler = FindFirstObjectByType<TimeHandler>();
        _dirLightHandle = FindFirstObjectByType<DirectionalLightHandler>();
        
        _gameStarted ??= new UnityEvent();
        
        _gameStarted.AddListener(_timeHandler.StartCountingTimer);
        _gameStarted.AddListener(_dirLightHandle.StartDayCycle);

        StartGame();
    }

    private void StartGame()
    {
        _gameStarted.Invoke();
    }
}
