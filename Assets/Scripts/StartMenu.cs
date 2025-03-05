using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu; // Assign StartMenu panel
    public Button startButton; // Assign Start button
    public IntroTextManager introTextManager; // Assign IntroTextManager script

    void Start()
    {
        if (startMenu != null)
            startMenu.SetActive(true); // Ensure start menu is visible at the beginning

        if (startButton != null)
            startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        if (startMenu != null)
            startMenu.SetActive(false); // Hide start menu

        if (introTextManager != null)
        {
            Debug.Log("Starting intro text...");
            introTextManager.StartIntroText();
        }
        else
        {
            Debug.LogError("IntroTextManager is not assigned in StartMenu!");
        }
    }
}
