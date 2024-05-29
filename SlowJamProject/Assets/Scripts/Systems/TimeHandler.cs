using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimeHandler : MonoBehaviour
{
    private TMP_Text _timerText;

    [SerializeField] private int currentTime = 11;
    private bool _am;
    private string _ampmString;
    [field: SerializeField] public float TimeStep { get; private set; }

    private GameManager _gameManager;

    private UnityEvent _timeIsUp;

    [SerializeField] private int timeToEndAt;
    [SerializeField] private bool endOnAM;

    private void Awake()
    {
        _timerText = GetComponent<TMP_Text>();
        _gameManager = FindFirstObjectByType<GameManager>();

        _timeIsUp ??= new UnityEvent();

        _timeIsUp.AddListener(_gameManager.EndGame);
    }

    public void StartCountingTimer()
    {
        InvokeRepeating(nameof(IncrementClock), 0, TimeStep);
    }

    public void StopCountingTimer()
    {
        CancelInvoke(nameof(IncrementClock));
    }

    private void IncrementClock()
    {
        currentTime++;
        switch (currentTime)
        {
            case > 11 and <= 12:
                _am = !_am;
                break;
            case > 12:
                currentTime = 1;
                break;
        }

        _ampmString = !_am ? "PM" : "AM";

        _timerText.text = $"{currentTime} {_ampmString}";

        if (currentTime == timeToEndAt && endOnAM == _am)
        {
            _timeIsUp.Invoke();
        }
    }
}