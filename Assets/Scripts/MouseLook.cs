using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 50f;
    public Transform playerBody; // Reference to the player's body for horizontal rotation
    private float xRotation = 0f; // vertical rotation

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // Lock the cursor to the game window
        Cursor.visible = true; // Show the cursor
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)) {
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
            Cursor.visible = false; // Hide the cursor

            float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

            playerBody.Rotate(Vector3.up * mouseX); // Rotate the player's body horizontally

            xRotation -= mouseY; // Invert the vertical rotation
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the vertical rotation to prevent the player from looking behind them

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotate the camera vertically
        }
        else {
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true; // Show the cursor
        }
        
    }
}
