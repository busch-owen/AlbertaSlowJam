using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private UnityEvent _gameStarted;

    private TimeTextHandler _timeTextHandler;

    private void Awake()
    {
        _timeTextHandler = FindFirstObjectByType<TimeTextHandler>();
        
        _gameStarted ??= new UnityEvent();
        
        _gameStarted.AddListener(_timeTextHandler.StartCountingTimer);

        StartGame();
    }

    private void StartGame()
    {
        _gameStarted.Invoke();
    }
}
