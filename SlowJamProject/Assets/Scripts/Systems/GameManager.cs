using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private UnityEvent _gameStarted;
    private UnityEvent _gameEnded;

    private TimeHandler _timeHandler;
    private DirectionalLightHandler _dirLightHandle;
    private MainMenu _mainMenu;

    private void Awake()
    {
        _timeHandler = FindFirstObjectByType<TimeHandler>();
        _dirLightHandle = FindFirstObjectByType<DirectionalLightHandler>();
        _mainMenu = FindFirstObjectByType<MainMenu>();
        
        _gameStarted ??= new UnityEvent();
        _gameEnded ??= new UnityEvent();
        
        _gameStarted.AddListener(_timeHandler.StartCountingTimer);
        _gameEnded.AddListener(_timeHandler.StopCountingTimer);
        _gameStarted.AddListener(_dirLightHandle.StartDayCycle);
        _gameEnded.AddListener(_dirLightHandle.StopDayCycle);
        _gameStarted.AddListener(_mainMenu.CloseMainMenu);
    }

    public void StartGame()
    {
        _gameStarted.Invoke();
    }

    public void EndGame()
    {
        Debug.Log("Game ended");
        _gameEnded.Invoke();
    }
}
