using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationAmount = 10f; // Amount of rotation in degrees
    public KeyCode rotateKey = KeyCode.E; // Key to trigger rotation
    public KeyCode resetKey = KeyCode.Q; // Key to reset rotation

    private Quaternion originalRotation; // Store the original rotation
    private bool isRotated = false;
    private bool rotationCooldown = false; // Cooldown flag

    void Start()
    {
        // Store the original rotation when the script starts
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Check if rotation cooldown is active
        if (rotationCooldown)
            return; // Exit the update loop if cooldown is active

        // Check if the rotation key is pressed and rotation hasn't occurred yet
        if (!isRotated && Input.GetKeyDown(rotateKey))
        {
            Debug.Log("Rotation Triggered");
            // Rotate the camera on the Y-axis by the specified amount
            transform.Rotate(0f, rotationAmount, 0f);
            isRotated = true; // Mark rotation as occurred
            rotationCooldown = true; // Activate cooldown
            Invoke("ResetCooldown", 0.5f); // Reset cooldown after 0.5 seconds
        }
        // If the camera is rotated and the rotation key is pressed again, reset its rotation
        else if (isRotated && Input.GetKeyDown(rotateKey))
        {
            Debug.Log("Reset Rotation Triggered");
            // Reset camera rotation to the original rotation
            transform.rotation = originalRotation;
            isRotated = false; // Mark rotation as reset
        }

        // Check if the reset key is pressed
        if (Input.GetKeyDown(resetKey))
        {
            Debug.Log("Reset Triggered");
            // Reset camera rotation to the original rotation
            transform.rotation = originalRotation;
            isRotated = false; // Mark rotation as reset
            rotationCooldown = true; // Activate cooldown
            Invoke("ResetCooldown", 0.5f); // Reset cooldown after 0.5 seconds
        }
    }

    // Method to reset the rotation cooldown
    private void ResetCooldown()
    {
        rotationCooldown = false; // Reset cooldown flag
    }
}
