using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 5f;
    public TextMeshProUGUI interactionText;
    public TextMeshProUGUI pickUpPrompt;
    public Image itemImage;
    public GameObject interactionPanel;

    private InteractableItem currentItem;
    private bool canPickUp = false;
    public LayerMask interactableLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (interactionPanel != null)
        {
            interactionPanel.SetActive(false);
        }

        if (pickUpPrompt != null)
        {
            pickUpPrompt.gameObject.SetActive(false);
        }

        if (itemImage != null)
        {
            itemImage.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Handle mouse click to show item interaction
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    InteractableItem item = hit.collider.GetComponent<InteractableItem>();
                    if (item != null)
                    {
                        ShowItemInteraction(item);
                    }
                }
            }
        }

        // Handle E key to pick up the item
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }

        // Handle Escape key to close the interaction
        if (Input.GetKeyDown(KeyCode.Escape) && interactionPanel.activeSelf)
        {
            CloseInteraction();
        }
    }

    void ShowItemInteraction(InteractableItem item)
    {
        currentItem = item;
        if (interactionPanel != null)
        {
            interactionPanel.SetActive(true);
        }
        if (interactionText != null)
        {
            interactionText.text = item.interactionText;
        }
        if (itemImage != null)
        {
            itemImage.sprite = item.itemSprite;
            itemImage.gameObject.SetActive(true);
        }
        if (pickUpPrompt != null)
        {
            pickUpPrompt.text = "Press E to pick up the " + currentItem.itemName;
            pickUpPrompt.gameObject.SetActive(true);
            canPickUp = true;
        }

        Time.timeScale = 0f;
    }

    void PickUpItem()
    {
        if (currentItem != null)
        {
            currentItem.gameObject.SetActive(false);
            GameManager.Instance.CollectItem(); // Notify GameManager when an item is picked up
        }
        if (interactionPanel != null)
        {
            interactionPanel.SetActive(false);
        }
        if (pickUpPrompt != null)
        {
            pickUpPrompt.gameObject.SetActive(false);
        }

        Time.timeScale = 1f;
        currentItem = null;
        canPickUp = false;
    }

    void CloseInteraction()
    {
        if (interactionPanel != null)
            interactionPanel.SetActive(false);

        if (pickUpPrompt != null)
            pickUpPrompt.gameObject.SetActive(false);

        Time.timeScale = 1f;
        currentItem = null;
        canPickUp = false;
    }
}
