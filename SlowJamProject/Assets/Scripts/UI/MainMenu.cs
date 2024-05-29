using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    
    public void CloseMainMenu()
    {
        mainMenu.SetActive(false);
    }
}
