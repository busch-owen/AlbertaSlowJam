using TMPro;
using UnityEngine;

public class TimeTextHandler : MonoBehaviour
{
    private TMP_Text _timerText;

    private int _currentTime = 11;
    private bool _am;
    private string _ampmString;
    [SerializeField] private float timeStep;

    private void Awake()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    public void StartCountingTimer()
    {
        InvokeRepeating(nameof(IncrementClock), 0, timeStep);
    }

    private void IncrementClock()
    {
        _currentTime++;
        if (_currentTime > 12)
        {
            _currentTime = 1;
            _am = !_am;
        }

        _ampmString = !_am ? "PM" : "AM";
        
        _timerText.text = $"{_currentTime} {_ampmString}";
    }
}