using System.Collections;
using TMPro;
using UnityEngine;

public class GoToBedMessageManager : MonoBehaviour
{
    public GameObject messagePanel; // Assign the panel for the "go to bed" message
    public TextMeshProUGUI messageText; // Assign the TextMeshProUGUI for the message
    public float typingSpeed = 0.05f; // Speed of typing
    public float fadeDuration = 1f; // Duration of the fade-out effect
    public float displayDelay = 5f; // Delay before fading out

    private Coroutine typingCoroutine;

    void Start()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false); // Hide the panel at the start
    }

    public void ShowGoToBedMessage()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(true);
            messageText.text = ""; // Clear the text before typing

            // Define the "go to bed" message
            string goToBedMessage =
                "Looking around, I think everything is in its place. It’s getting late, I should go to bed and get ready for my first day at the university tomorrow.";

            // Start typing the message
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeGoToBedMessage(goToBedMessage));
        }
        else
        {
            Debug.LogError("Message Panel is NULL!");
        }
    }

    private IEnumerator TypeGoToBedMessage(string message)
    {
        // Type the message letter by letter
        foreach (char letter in message)
        {
            messageText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Wait for a few seconds before fading out
        yield return new WaitForSeconds(displayDelay);

        // Start the fade-out process
        StartCoroutine(FadeOutText());
    }

    private IEnumerator FadeOutText()
    {
        float elapsedTime = 0f;
        Color textColor = messageText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            messageText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
            yield return null;
        }

        messagePanel.SetActive(false);
    }
}
