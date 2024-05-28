using TMPro;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    private TMP_Text _timerText;

    [SerializeField] private int currentTime = 11;
    private bool _am;
    private string _ampmString;
    [field: SerializeField] public float TimeStep { get; private set; }

    private void Awake()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    public void StartCountingTimer()
    {
        InvokeRepeating(nameof(IncrementClock), 0, TimeStep);
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
    }
}