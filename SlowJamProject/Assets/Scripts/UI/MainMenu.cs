using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    [SerializeField]
    Button _startButton;

    void Awake()
    {
        _startButton = GetComponentInChildren<Button>();
        _startButton.onClick.AddListener(StartGame);
    }
    
    public void CloseMainMenu()
    {
        mainMenu.SetActive(false);
    }

    void StartGame()
    {
        GameManager.Instance.StartGame();
        CloseMainMenu();
    }
}
