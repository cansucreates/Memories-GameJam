using UnityEngine;
using UnityEngine.UI;

public class EndgameManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public Button endGameButton;

    void Start()
    {
        // Ensure the end game panel is hidden at the start
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(false);
        }

        // Assign the QuitGame method to the button's onClick event
        if (endGameButton != null)
        {
            endGameButton.onClick.AddListener(QuitGame);
        }
    }

    public void ShowEndGameScreen()
    {
        // Show the end game panel and pause the game
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    private void QuitGame()
    {
        // Quit the game
        Application.Quit();

        // If running in the editor, stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
