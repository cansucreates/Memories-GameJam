using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int collectedItems = 0;
    public int totalItems = 5;

    // Reference to the GoToBedMessageManager
    public GoToBedMessageManager goToBedMessageManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectItem()
    {
        collectedItems++; // Increase the count when an item is collected
        Debug.Log("Item Collected! Total: " + collectedItems + "/" + totalItems);

        // Check if all items are collected
        if (collectedItems >= totalItems)
        {
            if (goToBedMessageManager != null)
            {
                goToBedMessageManager.ShowGoToBedMessage(); // Show the "go to bed" message
            }
            else
            {
                Debug.LogWarning("GoToBedMessageManager is not assigned in GameManager.");
            }
        }
    }

    public bool CanInteractWithBed()
    {
        Debug.Log(
            "Checking if bed interaction is allowed. Collected: "
                + collectedItems
                + " / Required: "
                + totalItems
        );
        return collectedItems >= totalItems;
    }
}