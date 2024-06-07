using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    [SerializeField] private TMP_Text endText;
    [SerializeField] private string winString, loseString;
    [SerializeField] private GameObject menu;

    [SerializeField] private Button _playAgainButton;

    void Awake()
    {
        _playAgainButton = GetComponentInChildren<Button>();
        _playAgainButton.onClick.AddListener(RestartGame);
    }

    private void Start()
    {
        menu.SetActive(false);
    }
    
    public void DisplayWinScreen()
    {
        menu.SetActive(true);
        endText.text = winString;
    }

    public void DisplayLoseScreen()
    {
        menu.SetActive(true);
        endText.text = loseString;
    }

    void RestartGame()
    {
        GameManager.Instance.StartGame();
        GameManager.Instance.ResetLevel();
        menu.SetActive(false);
    }
}
