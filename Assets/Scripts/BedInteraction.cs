using UnityEngine;

public class BedInteraction : MonoBehaviour
{
    public EndgameManager endgameManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    if (GameManager.Instance.CanInteractWithBed())
                    {
                        Debug.Log("All items collected! Showing end game screen...");
                        endgameManager.ShowEndGameScreen();
                    }
                    else
                    {
                        Debug.Log("Not all items collected yet. Collect them before sleeping...");
                    }
                }
            }
        }
    }
}
