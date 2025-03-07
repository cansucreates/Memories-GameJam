using System.Collections;
using TMPro;
using UnityEngine;

public class IntroTextManager : MonoBehaviour
{
    public GameObject introPanel; // Assign IntroTextPanel
    public TextMeshProUGUI introText; // Assign IntroText UI element
    public float typingSpeed = 0.05f;
    public float sentenceDelay = 2f;
    public float fadeDuration = 1f;

    private string[] sentences = new string[]
    {
        "Today is my first day as a young adult. I'm moving into my flat.",
        "I asked my parents to help me around the house. They’ve been with me all day and just left.",
        "It feels empty being by myself for the first time. I guess that’s a part of growing up.",
        "I should tidy up my room, there’s only little to do.",
    };

    private int currentSentenceIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        if (introPanel != null)
            introPanel.SetActive(false); // Hide intro panel at the start
    }

    public void StartIntroText()
    {
        if (introPanel != null)
        {
            introPanel.SetActive(true);
            introText.text = "";
            currentSentenceIndex = 0;

            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeSentence(sentences[currentSentenceIndex]));
        }
        else
        {
            Debug.LogError("Intro Panel is NULL!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && introPanel.activeSelf)
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                introText.text = sentences[currentSentenceIndex];
                isTyping = false;
            }
            else
            {
                NextSentence();
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        introText.text = "";
        foreach (char letter in sentence)
        {
            introText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        yield return new WaitForSeconds(sentenceDelay);
        NextSentence();
    }

    void NextSentence()
    {
        if (currentSentenceIndex < sentences.Length - 1)
        {
            currentSentenceIndex++;
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeSentence(sentences[currentSentenceIndex]));
        }
        else
        {
            StartCoroutine(FadeOutText());
        }
    }

    IEnumerator FadeOutText()
    {
        float elapsedTime = 0f;
        Color textColor = introText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            introText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
            yield return null;
        }

        introPanel.SetActive(false);
    }
}