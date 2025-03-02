using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu;
    public TextMeshProUGUI gameTitle;
    public Button startButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (startMenu != null)
        {
            startMenu.SetActive(true);
            startButton.onClick.AddListener(StartGame);
        }
    }

    void StartGame()
    {
        if (startMenu != null)
        {
            startMenu.SetActive(false);
        }

        Time.timeScale = 1f;

        Debug.Log("Game Started!");
    }
}
