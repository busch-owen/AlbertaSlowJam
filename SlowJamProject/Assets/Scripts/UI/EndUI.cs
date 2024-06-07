using TMPro;
using UnityEngine;

public class EndUI : MonoBehaviour
{
    [SerializeField] private TMP_Text endText;
    [SerializeField] private string winString, loseString;
    [SerializeField] private GameObject menu;

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
}
